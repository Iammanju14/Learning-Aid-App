package com.example.studycatalog;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class FeedBackPostActivity extends NavigationDrawerBaseActivity {

    TextView tvMaterialID, tvStudentName;
    EditText etFeedBack;
    Button btnPostFeedBack;

    ConnectionClass connectionClass = new ConnectionClass();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_feed_back_post);

        super.OnCreateDrawer();

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitle("Post Offense");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        tvMaterialID = (TextView) findViewById(R.id.tvMaterialID);
        tvStudentName = (TextView) findViewById(R.id.tvStudentName);
        etFeedBack = (EditText) findViewById(R.id.etFeedBack);

        btnPostFeedBack=(Button) findViewById(R.id.btnPostFeedBack);

        String ID;
        Intent intent = getIntent();
        if (intent != null) {
            tvMaterialID.setText(intent.getExtras().getString("ID"));
        } else {

        }

        //fetching value from shared preference
        SharedPreferences sharedPreferences = getApplicationContext().getSharedPreferences("LK", 0);
        tvStudentName.setText(sharedPreferences.getString("user_name", ""));

        btnPostFeedBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try {
                    Connection conn = connectionClass.CONN(); //Connection Object

                    if (conn == null) {
                        Toast.makeText(getApplicationContext(), "No Internet", Toast.LENGTH_LONG).show();
                    } else {

                        //fetching value from shared preference
                        SharedPreferences sharedPreferences = getApplicationContext().getSharedPreferences("LK", 0);
                        String user_id = sharedPreferences.getString("user_id", "");

                        int ID=0;
                        String query1 = "Select ID from tblFeedBack order by 1 Desc";
                        PreparedStatement preparedStatement2 = conn.prepareStatement(query1);
                        ResultSet rs = preparedStatement2.executeQuery();
                        if (rs.next()){
                            String inID=rs.getString("ID");
                            ID=Integer.parseInt(inID.toString());
                            ID=ID+1;
                        }else{
                            ID=1;
                        }

                        String query2 = "Insert into tblFeedBack (ID,MaterialID,StudentName,FeedBack,PostedBy) " +
                                "values ('" + ID + "','" + tvMaterialID.getText().toString().trim() + "'," +
                                "'" + tvStudentName.getText().toString().trim() + "'," +
                                "'" + etFeedBack.getText().toString().trim() + "', " +
                                "'" + user_id + "')";
                        preparedStatement2 = conn.prepareStatement(query2);
                        preparedStatement2.executeUpdate();

                        Toast.makeText(getApplicationContext(), "Posted Successfully. ", Toast.LENGTH_LONG).show();

                        Intent i = new Intent(FeedBackPostActivity.this, FeedBackListActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        i.putExtra("ID", tvMaterialID.getText().toString());
                        startActivity(i);

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
        Intent i = new Intent(FeedBackPostActivity.this, FeedBackListActivity.class);
        i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        i.putExtra("ID", tvMaterialID.getText().toString());
        finish();
        startActivity(i);
    }
}