package com.example.edutask.services;

import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.util.Log;

import com.example.edutask.models.Assignment;
import com.example.edutask.receivers.DeadlineReminderReceiver;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class NotificationService {
    private static final String TAG = "NotificationService";
    private Context context;
    private AlarmManager alarmManager;

    public NotificationService(Context context) {
        this.context = context;
        this.alarmManager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
    }

    public void scheduleDeadlineReminders(Assignment assignment) {
        if (assignment.getDeadline() == null) return;

        Date deadline = assignment.getDeadline();
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(deadline);

        // Reminder 1 day before
        Calendar oneDayBefore = (Calendar) calendar.clone();
        oneDayBefore.add(Calendar.DAY_OF_MONTH, -1);
        scheduleReminder(assignment, oneDayBefore.getTimeInMillis(), 1);

        // Reminder 3 hours before
        Calendar threeHoursBefore = (Calendar) calendar.clone();
        threeHoursBefore.add(Calendar.HOUR_OF_DAY, -3);
        scheduleReminder(assignment, threeHoursBefore.getTimeInMillis(), 2);
    }

    private void scheduleReminder(Assignment assignment, long triggerTime, int requestCode) {
        if (triggerTime <= System.currentTimeMillis()) {
            return; // Don't schedule past reminders
        }

        Intent intent = new Intent(context, DeadlineReminderReceiver.class);
        intent.putExtra("assignmentId", assignment.getAssignmentId());
        intent.putExtra("title", assignment.getTitle());
        intent.putExtra("deadline", assignment.getDeadline().getTime());

        PendingIntent pendingIntent = PendingIntent.getBroadcast(
                context,
                requestCode,
                intent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE
        );

        alarmManager.setExact(AlarmManager.RTC_WAKEUP, triggerTime, pendingIntent);
        Log.d(TAG, "Scheduled reminder for assignment: " + assignment.getTitle());
    }

    public void cancelReminders(String assignmentId) {
        Intent intent = new Intent(context, DeadlineReminderReceiver.class);
        PendingIntent pendingIntent1 = PendingIntent.getBroadcast(
                context,
                1,
                intent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE
        );
        PendingIntent pendingIntent2 = PendingIntent.getBroadcast(
                context,
                2,
                intent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE
        );

        alarmManager.cancel(pendingIntent1);
        alarmManager.cancel(pendingIntent2);
    }
}
