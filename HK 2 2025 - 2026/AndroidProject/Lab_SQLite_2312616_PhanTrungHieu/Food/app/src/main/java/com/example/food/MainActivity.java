package com.example.food;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ListView lvMonAn;
    ArrayList<MonAn> arrayMonAn;
    MonAnAdapter adapter;
    Database database;

    public static final int EDIT_MONAN_REQUEST = 1;
    private static final int ADD_MONAN_REQUEST = 2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvMonAn = findViewById(R.id.listviewMonAn);
        arrayMonAn = new ArrayList<>();
        adapter = new MonAnAdapter(this, R.layout.list_item_monan, arrayMonAn);
        lvMonAn.setAdapter(adapter);

        // Khởi tạo database
        database = new Database(this);

        // Lấy dữ liệu và hiển thị
        GetDataMonAn();

        registerForContextMenu(lvMonAn);
    }

    private void GetDataMonAn(){
        // Lấy dữ liệu từ database
        Cursor dataMonAn = database.GetData("SELECT * FROM MonAn");
        arrayMonAn.clear(); // Xóa dữ liệu cũ
        while (dataMonAn.moveToNext()){
            int id = dataMonAn.getInt(0);
            String ten = dataMonAn.getString(1);
            String moTa = dataMonAn.getString(2);
            String gia = dataMonAn.getString(3);
            String hinh = dataMonAn.getString(4); // Đổi sang getString
            arrayMonAn.add(new MonAn(id, ten, moTa, gia, hinh));
        }
        adapter.notifyDataSetChanged(); // Cập nhật lại adapter
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.option_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if (item.getItemId() == R.id.menuThem) {
            Intent intent = new Intent(MainActivity.this, AddMonAnActivity.class);
            startActivityForResult(intent, ADD_MONAN_REQUEST);
        } else if (item.getItemId() == R.id.menuThoat) {
            finish();
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        getMenuInflater().inflate(R.menu.context_menu, menu);
        menu.setHeaderTitle("Chọn chức năng");
        super.onCreateContextMenu(menu, v, menuInfo);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        int position = info.position;
        MonAn selectedMonAn = arrayMonAn.get(position);

        if (item.getItemId() == R.id.menuSua) {
            Intent intent = new Intent(this, EditMonAnActivity.class);
            intent.putExtra("monan", selectedMonAn);
            startActivityForResult(intent, EDIT_MONAN_REQUEST);
        } else if (item.getItemId() == R.id.menuXoa) {
            deleteMonAn(selectedMonAn.getId());
        }
        return super.onContextItemSelected(item);
    }

    public void deleteMonAn(int id){
        database.QueryData("DELETE FROM MonAn WHERE Id = '" + id + "'");
        Toast.makeText(this, "Đã xóa món ăn!", Toast.LENGTH_SHORT).show();
        GetDataMonAn();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_OK && data != null) {
            if (requestCode == EDIT_MONAN_REQUEST) {
                MonAn updatedMonAn = (MonAn) data.getSerializableExtra("updatedMonAn");
                String hinh = updatedMonAn.getHinh();

                database.QueryData("UPDATE MonAn SET Ten = '" + updatedMonAn.getTen() + "', MoTa = '"+ updatedMonAn.getMoTa() +"', Gia = '"+ updatedMonAn.getGia() +"', Hinh = '" + hinh + "' WHERE Id = '" + updatedMonAn.getId() + "'");
                Toast.makeText(this, "Đã cập nhật!", Toast.LENGTH_SHORT).show();
            } else if (requestCode == ADD_MONAN_REQUEST) {
                String ten = data.getStringExtra("ten");
                String moTa = data.getStringExtra("moTa");
                String gia = data.getStringExtra("gia");
                String hinh = data.getStringExtra("hinh");

                database.QueryData("INSERT INTO MonAn VALUES(null, '" + ten + "', '" + moTa + "', 'Giá: " + gia + "', '" + hinh + "')");
                Toast.makeText(this, "Đã thêm món mới!", Toast.LENGTH_SHORT).show();
            }
            GetDataMonAn(); // Tải lại dữ liệu sau khi thêm hoặc sửa
        }
    }
}
