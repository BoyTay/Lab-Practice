package vn.edu.dlu.ctk47.mssv2312616;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import java.text.DecimalFormat;
import java.util.List;

public class TransactionAdapter extends RecyclerView.Adapter<TransactionAdapter.ViewHolder> {
    private List<Transaction> transactions;
    private List<Category> categories;
    private List<Account> accounts;
    private OnItemClickListener listener;

    private DecimalFormat df = new DecimalFormat("#,###");

    public interface OnItemClickListener {
        void onItemClick(Transaction transaction);
    }

    public TransactionAdapter(List<Transaction> transactions, List<Category> categories, List<Account> accounts, OnItemClickListener listener) {
        this.transactions = transactions;
        this.categories = categories;
        this.accounts = accounts;
        this.listener = listener;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(android.R.layout.simple_list_item_2, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Transaction t = transactions.get(position);
        
        String catName = "";
        int type = 0;
        for (Category c : categories) {
            if (c.getId() == t.getCat_id()) {
                catName = c.getName();
                type = c.getType();
                break;
            }
        }

        String accName = "";
        for (Account a : accounts) {
            if (a.getId() == t.getAcc_id()) {
                accName = a.getName();
                break;
            }
        }

        holder.text1.setText(accName + " - " + catName);

        String formattedAmount = df.format(t.getAmount());
        
        String prefix = (type == 1) ? "+" : "-";
        holder.text2.setText(prefix + formattedAmount + "đ (" + t.getDate() + ")");
        holder.text2.setTextColor(type == 1 ? 0xFF4CAF50 : 0xFFF44336);

        holder.itemView.setOnClickListener(v -> {
            if (listener != null) {
                listener.onItemClick(t);
            }
        });
    }

    @Override
    public int getItemCount() {
        return transactions.size();
    }

    class ViewHolder extends RecyclerView.ViewHolder {
        TextView text1, text2;
        ViewHolder(View view) {
            super(view);
            text1 = view.findViewById(android.R.id.text1);
            text2 = view.findViewById(android.R.id.text2);
        }
    }
}
