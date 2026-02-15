package com.example.account;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.fragment.app.Fragment;

public class M000LoginFragment extends Fragment {
    SQLiteHelper helper;
    Context mContext;

    public M000LoginFragment() {
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

        View view = inflater.inflate(R.layout.m000_frg_login, container, false);

        EditText edtEmail = view.findViewById(R.id.edt_email);
        EditText edtPass = view.findViewById(R.id.edt_pass);
        TextView tvLogin = view.findViewById(R.id.tv_login);
        TextView tvRegister = view.findViewById(R.id.tv_register);

        tvLogin.setOnClickListener(v -> {
            login(
                    edtEmail.getText().toString(),
                    edtPass.getText().toString()
            );
        });

        tvRegister.setOnClickListener(v -> {
            getParentFragmentManager()
                    .beginTransaction()
                    .replace(R.id.ln_main, new M001RegisterFragment())
                    .addToBackStack(null)
                    .commit();
        });

        return view;
    }
    private void login(String mail, String pass) {

        if (mail.isEmpty() || pass.isEmpty()) {
            Toast.makeText(mContext, "Empty value", Toast.LENGTH_SHORT).show();
            return;
        }

        if (helper.login(mail, pass)) {
            Toast.makeText(mContext, "Login account successfully!", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(mContext, "Wrong email or password!", Toast.LENGTH_SHORT).show();
        }
    }
}
