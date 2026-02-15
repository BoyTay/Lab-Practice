package com.example.funnystories;

import android.os.Parcel;
import android.os.Parcelable;

public class StoryEntity implements Parcelable {
    public String title;
    public String content;

    public StoryEntity(String title, String content) {
        this.title = title;
        this.content = content;
    }

    protected StoryEntity(Parcel in) {
        title = in.readString();
        content = in.readString();
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(title);
        dest.writeString(content);
    }

    @Override
    public int describeContents() {
        return 0;
    }

    public static final Creator<StoryEntity> CREATOR = new Creator<StoryEntity>() {
        @Override
        public StoryEntity createFromParcel(Parcel in) {
            return new StoryEntity(in);
        }

        @Override
        public StoryEntity[] newArray(int size) {
            return new StoryEntity[size];
        }
    };
}
