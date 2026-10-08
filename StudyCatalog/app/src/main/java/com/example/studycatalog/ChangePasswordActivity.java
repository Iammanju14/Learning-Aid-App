package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class ChangePasswordActivity extends NavigationDrawerBaseActivity {

    EditText etMobile,etPassword,etNewPassword,etConfirmPassword;
    Button btnUpdate;

    ConnectionClass connectionClass = new ConnectionClass();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_password);

        super.OnCreateDrawer();

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitle("Change Password");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        etMobile = (EditText) findViewById(R.id.etMobile);
        etPassword=(EditText) findViewById(R.id.etPassword);
        etNewPassword=(EditText)findViewById(R.id.etNewPassword);
        etConfirmPassword=(EditText) findViewById(R.id.etConfirmPassword);
        btnUpdate=(Button) findViewById(R.id.btnUpdate);

        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(etNewPassword.getText().toString().equals(etConfirmPassword.getText().toString())) {
                    try {
                        Connection conn = connectionClass.CONN(); //Connection Object

                        if (conn == null) {
                            Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                        } else {
                            String query1 = "Select * from tblLogin where UserID='" + etMobile.getText().toString() + "' and Password='" + etPassword.getText().toString() + "'";
                            PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                            ResultSet rs = preparedStatement2.executeQuery();
                            if (rs.next()) {

                                String query2 = "Update tblLogin set Password='" + etNewPassword.getText().toString() + "' " +
                                        "where UserID='" + etMobile.getText().toString() + "'";
                                preparedStatement2 = conn.prepareStatement(query2);
                                preparedStatement2.executeUpdate();

                                Toast.makeText(getApplicationContext(), "Updated Successfully. ", Toast.LENGTH_LONG).show();
                            }
                            else
                            {
                                Toast.makeText(getApplicationContext(), "You entered invalid Mobile or Password.", Toast.LENGTH_LONG).show();
                            }
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                        Writer writer = new StringWriter();
                        e.printStackTrace(new PrintWriter(writer));

                        Toast.makeText(getApplicationContext(), writer.toString(), Toast.LENGTH_LONG).show();
                    }
                }
                else
                {
                    Toast.makeText(getApplicationContext(), "Password does not match", Toast.LENGTH_LONG).show();
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
}