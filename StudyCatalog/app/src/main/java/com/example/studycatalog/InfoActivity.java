package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;

import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

public class InfoActivity extends NavigationDrawerBaseActivity {

    EditText etName, etEmailID;
    TextView tvMobile,tvState,tvDistrict,tvTaluk,tvCollege,tvCourse;
    Spinner spinnerSemOrYear;

    Button btnUpdate;

    ConnectionClass connectionClass = new ConnectionClass();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info);

        super.OnCreateDrawer();

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitle("Change Password");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        etName = (EditText) findViewById(R.id.etName);
        tvMobile = (TextView) findViewById(R.id.tvMobile);
        etEmailID = (EditText) findViewById(R.id.etEmailID);
        tvState = (TextView) findViewById(R.id.tvState);
        tvDistrict = (TextView) findViewById(R.id.tvDistrict);
        tvTaluk = (TextView) findViewById(R.id.tvTaluk);
        tvCollege = (TextView) findViewById(R.id.tvCollege);
        tvCourse = (TextView) findViewById(R.id.tvCourse);
        spinnerSemOrYear = (Spinner) findViewById(R.id.spinnerSemOrYear);

        btnUpdate = (Button) findViewById(R.id.btnUpdate);

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
                    etName.setText(rs.getString("Name").toString());
                    tvMobile.setText(rs.getString("Mobile").toString());
                    etEmailID.setText(rs.getString("EmailID").toString());
                    tvState.setText(rs.getString("State").toString());
                    tvDistrict.setText(rs.getString("District").toString());
                    tvTaluk.setText(rs.getString("Taluk").toString());
                    tvCollege.setText(rs.getString("College").toString());
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

        btnUpdate.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                if (!setValidation())
                    return;

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {
                        String query2 = "Update tblStudents set Name='" + etName.getText().toString() + "'," +
                                "EmailID='" + etEmailID.getText().toString() + "'," +
                                "SemorYear='" + spinnerSemOrYear.getSelectedItem().toString() + "' " +
                                " where Mobile='" + tvMobile.getText().toString() + "'";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query2);
                        preparedStatement2.executeUpdate();

                        Toast.makeText(getApplicationContext(), "Updated Successfully. ", Toast.LENGTH_LONG).show();

                        Intent intent = new Intent(InfoActivity.this, InfoActivity.class);
                        finish();
                        startActivity(intent);

                    }
                } catch (Exception e) {
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
        finish();
        startActivity(new Intent(getApplicationContext(),HomeActivity.class));
    }

    private boolean setValidation() {

        boolean isName,isEmailID;

        if ( etName.getText().toString().trim().isEmpty()) {
            etName.setError("Name can't be empty");
            isName = false;
        } else {
            etName.setError(null);
            isName = true;
        }

        if (etEmailID.getText().toString().trim().isEmpty()) {
            etEmailID.setError("Email ID can't be empty");
            isEmailID = false;
        } else {
            etEmailID.setError(null);
            isEmailID = true;
        }


        if(isName==true && isEmailID==true)
            return true;
        else
            return false;
    }


}