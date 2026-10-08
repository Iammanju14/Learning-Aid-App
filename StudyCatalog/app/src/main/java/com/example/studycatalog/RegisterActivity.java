package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.security.SecureRandom;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;

public class RegisterActivity extends AppCompatActivity {

    EditText etName, etMobile, etEmailID;
    Spinner spinnerState,spinnerDistrict,spinnerTaluk,spinnerCollege,spinnerCourse,spinnerSemOrYear;

    ConnectionClass connectionClass = new ConnectionClass();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        etName = (EditText) findViewById(R.id.etName);
        etMobile = (EditText) findViewById(R.id.etMobile);
        etEmailID = (EditText) findViewById(R.id.etEmailID);

        spinnerState = (Spinner) findViewById(R.id.spinnerState);
        spinnerDistrict = (Spinner) findViewById(R.id.spinnerDistrict);
        spinnerTaluk = (Spinner) findViewById(R.id.spinnerTaluk);
        spinnerCollege = (Spinner) findViewById(R.id.spinnerCollege);
        spinnerCourse = (Spinner) findViewById(R.id.spinnerCourse);
        spinnerSemOrYear = (Spinner) findViewById(R.id.spinnerSemOrYear);

        try {
            Connection conn = connectionClass.CONN(); //Connection Object

            if (conn == null) {
                Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
            } else {
                String query = ("SELECT distinct(State) FROM tblColleges");
                PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                ResultSet rs = preparedStatement2.executeQuery();
                ArrayList<String> data = new ArrayList<String>();

                String State;

                while (rs.next()){
                    State = rs.getString("State");
                    data.add(State);
                }
                String[] array = data.toArray(new String[0]);
                ArrayAdapter NoCoreAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, data);
                spinnerState.setAdapter(NoCoreAdapter);
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
                String query = ("SELECT distinct(Course) FROM tblCourse");
                PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                ResultSet rs = preparedStatement2.executeQuery();
                ArrayList<String> data = new ArrayList<String>();

                String Course;

                while (rs.next()){
                    Course = rs.getString("Course");
                    data.add(Course);
                }
                String[] array = data.toArray(new String[0]);
                ArrayAdapter NoCoreAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, data);
                spinnerCourse.setAdapter(NoCoreAdapter);
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


        spinnerState.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {

            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                String State = spinnerState.getSelectedItem().toString();

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {
                        String query = "SELECT distinct(District) From tblColleges where State='" + State + "'";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                        ResultSet rs = preparedStatement2.executeQuery();
                        ArrayList<String> data1 = new ArrayList<String>();

                        String District;

                        while (rs.next()){
                            District = rs.getString("District");
                            data1.add(District);
                        }
                        String[] array = data1.toArray(new String[0]);
                        ArrayAdapter NoCoreAdapter = new ArrayAdapter(getApplicationContext(), android.R.layout.simple_list_item_1, data1);
                        spinnerDistrict.setAdapter(NoCoreAdapter);
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


        spinnerDistrict.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {

            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                String State = spinnerState.getSelectedItem().toString();
                String District = spinnerDistrict.getSelectedItem().toString();

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {
                        String query = "SELECT distinct(Taluk) From tblColleges where State='" + State + "' and District='" + District + "'";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                        ResultSet rs = preparedStatement2.executeQuery();
                        ArrayList<String> data1 = new ArrayList<String>();

                        String Taluk;

                        while (rs.next()){
                            Taluk = rs.getString("Taluk");
                            data1.add(Taluk);
                        }
                        String[] array = data1.toArray(new String[0]);
                        ArrayAdapter NoCoreAdapter = new ArrayAdapter(getApplicationContext(), android.R.layout.simple_list_item_1, data1);
                        spinnerTaluk.setAdapter(NoCoreAdapter);
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



        spinnerTaluk.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {

            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                String State = spinnerState.getSelectedItem().toString();
                String District = spinnerDistrict.getSelectedItem().toString();
                String Taluk = spinnerTaluk.getSelectedItem().toString();

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {
                        String query = "SELECT distinct(College) From tblColleges where State='" + State + "' and District='" + District + "' and " +
                                "Taluk='" + Taluk + "'";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query);
                        ResultSet rs = preparedStatement2.executeQuery();
                        ArrayList<String> data1 = new ArrayList<String>();

                        String College;

                        while (rs.next()){
                            College = rs.getString("College");
                            data1.add(College);
                        }
                        String[] array = data1.toArray(new String[0]);
                        ArrayAdapter NoCoreAdapter = new ArrayAdapter(getApplicationContext(), android.R.layout.simple_list_item_1, data1);
                        spinnerCollege.setAdapter(NoCoreAdapter);
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

        findViewById(R.id.register).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (!setValidation())
                    return;

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {

                        String pwd= Integer.toString(generateRandomNumber());

                        int ID=0;
                        String query1 = "Select ID from tblStudents order by 1 Desc";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                        ResultSet rs = preparedStatement2.executeQuery();
                        if (rs.next()){
                            ID=Integer.parseInt(rs.getString("ID").toString());
                            ID=ID+1;
                        }else{
                            ID=1;
                        }

                        String query2 = "Insert into tblStudents (ID,Name,Mobile,EmailID,State,District,Taluk,College," +
                                "Course,SemorYear) " +
                                "values ('" + ID + "','" + etName.getText().toString().trim() + "'," +
                                "'" + etMobile.getText().toString().trim() + "'," +
                                "'" + etEmailID.getText().toString().trim() + "'," +
                                "'" + spinnerState.getSelectedItem().toString() + "'," +
                                "'" + spinnerDistrict.getSelectedItem().toString() + "'," +
                                "'" + spinnerTaluk.getSelectedItem().toString() + "'," +
                                "'" + spinnerCollege.getSelectedItem().toString() + "'," +
                                "'" + spinnerCourse.getSelectedItem().toString() + "'," +
                                "'" + spinnerSemOrYear.getSelectedItem().toString() + "')";
                        preparedStatement2 = conn.prepareStatement(query2);
                        preparedStatement2.executeUpdate();

                        query2 = "Insert into tblLogin (UserID,Password,UserType,UserName) values " +
                                "('" + etMobile.getText().toString().trim() + "','" + pwd + "','Student'," +
                                "'" + etName.getText().toString().trim() + "')";
                        preparedStatement2 = conn.prepareStatement(query2);
                        preparedStatement2.executeUpdate();

                        Toast.makeText(getApplicationContext(), "Registered Successfully. Password is "+pwd, Toast.LENGTH_LONG).show();

                        Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
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

        findViewById(R.id.login1).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
                startActivity(new Intent(getApplicationContext(),LoginActivity.class));
            }
        });
    }


    @Override
    public void onBackPressed() {
        // do something on back.
        finish();
        startActivity(new Intent(getApplicationContext(),LoginActivity.class));
    }

    private boolean setValidation() {

        boolean isName,isEmailID,isMobile;

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

        if (etMobile.getText().toString().isEmpty()) {
            etMobile.setError("Mobile can't be empty");
            isMobile= false;
        } else {
            etMobile.setError(null);
            isMobile=true;
        }

        if(isName==true && isEmailID==true && isMobile==true)
            return true;
        else
            return false;
    }

    public int generateRandomNumber() {
        int range = 9;  // to generate a single number with this range, by default its 0..9
        int length = 4; // by default length is 4

        int randomNumber;

        SecureRandom secureRandom = new SecureRandom();
        String s = "";
        for (int i = 0; i < length; i++) {
            int number = secureRandom.nextInt(range);
            if (number == 0 && i == 0) { // to prevent the Zero to be the first number as then it will reduce the length of generated pin to three or even more if the second or third number came as zeros
                i = -1;
                continue;
            }
            s = s + number;
        }

        randomNumber = Integer.parseInt(s);

        return randomNumber;
    }
}