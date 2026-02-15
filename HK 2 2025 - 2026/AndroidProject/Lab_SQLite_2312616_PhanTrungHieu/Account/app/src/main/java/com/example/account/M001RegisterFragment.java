package com.example.account;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.fragment.app.Fragment;

public class M001RegisterFragment extends Fragment {
    SQLiteHelper helper;
    Context mContext;

    public M001RegisterFragment() {
        // Required empty public constructor
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        mContext = context;
        if (context instanceof MainActivity) {
            helper = ((MainActivity) context).getHelper();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.m001_frg_register, container, false);

        ImageView ivBack = view.findViewById(R.id.iv_back);
        ivBack.setOnClickListener(v -> getParentFragmentManager().popBackStack());

        EditText edtEmail = view.findViewById(R.id.edt_email);
        EditText edtPass = view.findViewById(R.id.edt_pass);
        EditText edtRePass = view.findViewById(R.id.edt_re_pass);
        TextView tvRegister = view.findViewById(R.id.tv_register);

        tvRegister.setOnClickListener(v -> {
            register(
                    edtEmail.getText().toString(),
                    edtPass.getText().toString(),
                    edtRePass.getText().toString()
            );
        });

        return view;
    }
    private void register(String mail, String pass, String repass) {

        if (mail.isEmpty() || pass.isEmpty() || repass.isEmpty()) {
            Toast.makeText(mContext, "Empty value", Toast.LENGTH_SHORT).show();
            return;
        }

        if (!pass.equals(repass)) {
            Toast.makeText(mContext, "Password is not match", Toast.LENGTH_SHORT).show();
            return;
        }

        Account account = new Account(mail, pass);
        helper.insert(account);

        Toast.makeText(mContext, "Register successfully", Toast.LENGTH_SHORT).show();

        // Quay về Login
        getParentFragmentManager().popBackStack();
    }


}
