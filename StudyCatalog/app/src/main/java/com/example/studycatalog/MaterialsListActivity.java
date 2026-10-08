package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.DefaultItemAnimator;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.studycatalog.adapters.MaterialAdapter;
import com.example.studycatalog.data_models.MaterialDataType;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

public class MaterialsListActivity extends NavigationDrawerBaseActivity {

    TextView tvCourse;
    Spinner spinnerSemOrYear,spinnerSbject;

    Button btnSearch;

    ConnectionClass connectionClass = new ConnectionClass();

    RecyclerView recyclerView;
    ResultSet rss;
    ArrayList<MaterialDataType> ex;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_materials_list);

        super.OnCreateDrawer();

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitle("Materilas List");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        recyclerView = findViewById(R.id.recyclerView);
        RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(this);
        recyclerView.setLayoutManager(mLayoutManager);
        recyclerView.setItemAnimator(new DefaultItemAnimator());

        tvCourse = (TextView) findViewById(R.id.tvCourse);
        spinnerSemOrYear = (Spinner) findViewById(R.id.spinnerSemOrYear);
        spinnerSbject = (Spinner) findViewById(R.id.spinnerSbject);

        btnSearch=(Button) findViewById(R.id.btnSearch);

        try {
            Connection conn = connectionClass.CONN(); //Connection Object

            if (conn == null) {
                Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
            } else {
                String query = ("SELECT distinct(SemorYear) FROM tblSemorYear");
                PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                ResultSet rs = preparedStatement2.executeQuery();
                ArrayList<String> data = new ArrayList<String>();

                String SemorYear;

                while (rs.next()){
                    SemorYear = rs.getString("SemorYear");
                    data.add(SemorYear);
                }
                String[] array = data.toArray(new String[0]);
                ArrayAdapter NoCoreAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, data);
                spinnerSemOrYear.setAdapter(NoCoreAdapter);
            }
        }catch (Exception e) {
            e.printStackTrace();
            Writer writer = new StringWriter();
            e.printStackTrace(new PrintWriter(writer));

            Toast.makeText(getApplicationContext(), writer.toString(), Toast.LENGTH_LONG).show();
        }

        try {
            Connection conn = connectionClass.CONN(); //Connection Object

            if (conn == null) {

                Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
            } else {

                String Sem=null;

                //fetching value from shared preference
                SharedPreferences sharedPreferences = getApplicationContext().getSharedPreferences("LK", 0);
                String user_id = sharedPreferences.getString("user_id", "");

                String query1 = "Select * from tblStudents where Mobile='" + user_id + "'";
                PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                ResultSet rs = preparedStatement2.executeQuery();
                if (rs.next()) {
                    tvCourse.setText(rs.getString("Course").toString());
                    Sem = rs.getString("SemorYear").toString();
                }

                for (int i = 0; i < spinnerSemOrYear.getCount(); i++) {
                    if (spinnerSemOrYear.getItemAtPosition(i).equals(Sem)) {
                        spinnerSemOrYear.setSelection(i);
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
            Writer writer = new StringWriter();
            e.printStackTrace(new PrintWriter(writer));

            Toast.makeText(getApplicationContext(), writer.toString(), Toast.LENGTH_LONG).show();
        }




        spinnerSemOrYear.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {

            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                String Sem = spinnerSemOrYear.getSelectedItem().toString();

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {
                        String query = "SELECT distinct(Subject) From tblMaterials where Course='" + tvCourse.getText().toString() + "'" +
                                " and SemorYear='" + Sem + "'";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                        ResultSet rs = preparedStatement2.executeQuery();
                        ArrayList<String> data1 = new ArrayList<String>();

                        String Subject;

                        while (rs.next()){
                            Subject = rs.getString("Subject");
                            data1.add(Subject);
                        }
                        String[] array = data1.toArray(new String[0]);
                        ArrayAdapter NoCoreAdapter = new ArrayAdapter(getApplicationContext(), android.R.layout.simple_list_item_1, data1);
                        spinnerSbject.setAdapter(NoCoreAdapter);
                    }
                }catch (Exception e) {
                    e.printStackTrace();
                    Writer writer = new StringWriter();
                    e.printStackTrace(new PrintWriter(writer));

                    Toast.makeText(getApplicationContext(), writer.toString(), Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        btnSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {


                String Sem = spinnerSemOrYear.getSelectedItem().toString();
                String Subject = spinnerSbject.getSelectedItem().toString();

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {

                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else
                    {
                        String query="SELECT * from tblMaterials where SemorYear='" + Sem + "' " +
                                "and Subject='" + Subject + "' and Course='" + tvCourse.getText().toString() + "'";

                        PreparedStatement stmt = conn.prepareStatement(query);
                        rss = stmt.executeQuery();
                        ex = new ArrayList<>();
                        while(rss.next()) {
                            //Log.d("ResultSet", rs.getString("ID"));
                            MaterialDataType dt = new MaterialDataType();
                            dt.setID(rss.getString("ID").toString());
                            dt.setMaterial(rss.getString("Material").toString());
                            dt.setMaterialName(rss.getString("MaterialName").toString());
                            ex.add(dt);
                        }
                        MaterialAdapter eadapters = new MaterialAdapter(getApplicationContext(),ex);
                        recyclerView.setAdapter(eadapters);
                    }
                }
                catch (Exception e) {
                    e.printStackTrace();
                    Writer writer = new StringWriter();
                    e.printStackTrace(new PrintWriter(writer));

                    Toast.makeText(getApplicationContext(), writer.toString(), Toast.LENGTH_LONG).show();
                }
            }
        });
    }


    @Override
    public void onBackPressed() {
        // do something on back.
        Intent intent=new Intent(MaterialsListActivity.this,HomeActivity.class);
        finish();
        startActivity(intent);
    }
}