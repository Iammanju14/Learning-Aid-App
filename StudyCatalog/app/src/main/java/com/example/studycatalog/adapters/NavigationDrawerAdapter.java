package com.example.studycatalog.adapters;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;
import android.widget.Toast;


import com.example.studycatalog.AboutUsActivity;
import com.example.studycatalog.ChangePasswordActivity;
import com.example.studycatalog.HomeActivity;
import com.example.studycatalog.InfoActivity;
import com.example.studycatalog.LoginActivity;
import com.example.studycatalog.MaterialsListActivity;
import com.example.studycatalog.R;

public class NavigationDrawerAdapter extends BaseAdapter {
    private Context mContext = null;
    private String[] menuItemList = null;
    private LayoutInflater inflater = null;

    public NavigationDrawerAdapter(Context context, String[] list) {
        mContext = context;
        menuItemList = list;
    }
    @Override
    public int getCount() {
        return 6;
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        inflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rootView = inflater.inflate(R.layout.navigation_drawer_item_view_layout, null);

        TextView textView = rootView.findViewById(R.id.nav_menu_item_title);
        textView.setText(menuItemList[position]);
        rootView.setId(position);

        rootView.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                Intent i = null;

                switch (menuItemList[v.getId()]) {

                    case "Home":
                        i = new Intent(mContext, HomeActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
                        mContext.startActivity(i);
                        break;

                    case "Materials":
                        i = new Intent(mContext, MaterialsListActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
                        mContext.startActivity(i);
                        break;


                    case "Info":
                        i = new Intent(mContext, InfoActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
                        mContext.startActivity(i);
                        break;

                    case "Password":
                        i = new Intent(mContext, ChangePasswordActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
                        mContext.startActivity(i);
                        break;

                    case "About Us":
                        i = new Intent(mContext, AboutUsActivity.class);
                        i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
                        mContext.startActivity(i);
                        break;


                    case "Logout":

                        i = new Intent(mContext, LoginActivity.class);
                        mContext.startActivity(i);
                        ((Activity) mContext).finish();
                        break;

                    default:
                        Toast.makeText(mContext, "Something Wrong", Toast.LENGTH_SHORT).show();
                        break;

                }

            }

        });
        return rootView;
    }
}
