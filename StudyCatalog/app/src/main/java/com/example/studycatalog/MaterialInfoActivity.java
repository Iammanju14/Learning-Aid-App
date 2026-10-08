package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class MaterialInfoActivity extends NavigationDrawerBaseActivity {

    ConnectionClass connectionClass = new ConnectionClass();

    TextView tvID,tvCourse,tvSem,tvSubject,tvSubjectCode,tvDepartment,tvMaterial,tvMaterialName,tvDescription;
    TextView tvName,tvMobile,tvEmailID,tvState,tvDistrict,tvTaluk,tvCollege;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_material_info);

        super.OnCreateDrawer();

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitle("Registered Information");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        tvID=(TextView)findViewById(R.id.tvID);
        tvCourse=(TextView)findViewById(R.id.tvCourse);
        tvSem=(TextView)findViewById(R.id.tvSem);
        tvSubject=(TextView)findViewById(R.id.tvSubject);
        tvSubjectCode=(TextView)findViewById(R.id.tvSubjectCode);
        tvDepartment=(TextView)findViewById(R.id.tvDepartment);
        tvMaterial=(TextView)findViewById(R.id.tvMaterial);
        tvMaterialName=(TextView)findViewById(R.id.tvMaterialName);
        tvDescription=(TextView)findViewById(R.id.tvDescription);

        tvName=(TextView)findViewById(R.id.tvName);
        tvMobile=(TextView)findViewById(R.id.tvMobile);
        tvEmailID=(TextView)findViewById(R.id.tvEmailID);
        tvState=(TextView)findViewById(R.id.tvState);
        tvDistrict=(TextView)findViewById(R.id.tvDistrict);
        tvTaluk=(TextView)findViewById(R.id.tvTaluk);
        tvCollege=(TextView)findViewById(R.id.tvCollege);

        Intent intent = getIntent();
        if (intent != null) {
            tvID.setText(intent.getExtras().getString("ID"));
        } else {

        }

        try {
            Connection conn = connectionClass.CONN(); //Connection Object

            if (conn == null) {
                Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
            } else {
                String query1 = "Select * from tblMaterials where ID='" + tvID.getText().toString() + "'";
                PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                ResultSet rs = preparedStatement2.executeQuery();
                if (rs.next()) {
                    tvID.setText(rs.getString("ID").toString());
                    tvCourse.setText(rs.getString("Course").toString());
                    tvSem.setText(rs.getString("SemorYear").toString());
                    tvSubject.setText(rs.getString("Subject").toString());
                    tvSubjectCode.setText(rs.getString("SubjectCode").toString());
                    tvDepartment.setText(rs.getString("Department").toString());
                    tvMaterial.setText(rs.getString("Material").toString());
                    tvMaterialName.setText(rs.getString("MaterialName").toString());
                    tvDescription.setText(rs.getString("Description").toString());
                    tvMobile.setText(rs.getString("UpdatedBy").toString());
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


        try {
            Connection conn = connectionClass.CONN(); //Connection Object

            if (conn == null) {
                Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
            } else {
                String query1 = "Select * from tblLecturers where Mobile='" + tvMobile.getText().toString() + "'";
                PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                ResultSet rs = preparedStatement2.executeQuery();
                if (rs.next()) {
                    tvName.setText(rs.getString("Name").toString());
                    tvMobile.setText(rs.getString("Mobile").toString());
                    tvEmailID.setText(rs.getString("EmailID").toString());
                    tvState.setText(rs.getString("State").toString());
                    tvDistrict.setText(rs.getString("District").toString());
                    tvTaluk.setText(rs.getString("Taluk").toString());
                    tvCollege.setText(rs.getString("College").toString());
                    tvDepartment.setText(rs.getString("Department").toString());
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
    }
}