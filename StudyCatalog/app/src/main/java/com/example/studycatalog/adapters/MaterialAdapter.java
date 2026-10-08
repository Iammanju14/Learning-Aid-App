package com.example.studycatalog.adapters;

import android.content.Context;

import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.studycatalog.FeedBackListActivity;
import com.example.studycatalog.MaterialInfoActivity;
import com.example.studycatalog.MaterialViewActivity;
import com.example.studycatalog.R;
import com.example.studycatalog.data_models.MaterialDataType;


import java.util.ArrayList;

public class MaterialAdapter extends RecyclerView.Adapter<MaterialAdapter.ViewHolder>{

    Context context;
    ArrayList<MaterialDataType> ex;

    public MaterialAdapter(Context context, ArrayList<MaterialDataType> ex) {
        this.context = context;
        this.ex = ex;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        View v = LayoutInflater.from(this.context).inflate(R.layout.layout_material_item, parent, false);
        return new ViewHolder(v);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        final MaterialDataType dt = ex.get(position);

        holder.tvID.setText(dt.getID());
        holder.tvMaterialType.setText(dt.getMaterial());
        holder.tvMaterialName.setText(dt.getMaterialName());

        holder.btnInfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(context, MaterialInfoActivity.class);
                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                i.putExtra("ID", dt.getID());
                context.startActivity(i);
                //   Toast.makeText(context.getApplicationContext(), "Click on button", Toast.LENGTH_LONG).show();
            }
        });

        holder.btnViewMaterial.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(context, MaterialViewActivity.class);
                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                i.putExtra("ID", dt.getID());
                context.startActivity(i);
                //   Toast.makeText(context.getApplicationContext(), "Click on button", Toast.LENGTH_LONG).show();
            }
        });

       holder.btnFeedBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(context, FeedBackListActivity.class);
                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                i.putExtra("ID", dt.getID());
                context.startActivity(i);
                //   Toast.makeText(context.getApplicationContext(), "Click on button", Toast.LENGTH_LONG).show();
            }
        });
    }

    @Override
    public int getItemCount() {
        // Toast.makeText(context.getApplicationContext(), String.valueOf(ex.size()), Toast.LENGTH_LONG).show();
        return ex.size();
    }
    public class ViewHolder extends RecyclerView.ViewHolder {

        TextView tvID, tvMaterialType,tvMaterialName;
        Button btnInfo,btnFeedBack,btnViewMaterial;

        public ViewHolder(View view) {
            super(view);

            tvID = (TextView) view.findViewById(R.id.tvID);
            tvMaterialType = (TextView) view.findViewById(R.id.tvMaterialType);
            tvMaterialName=(TextView)view.findViewById(R.id.tvMaterialName);

            btnInfo=(Button) view.findViewById(R.id.btnInfo);
            btnFeedBack=(Button) view.findViewById(R.id.btnFeedBack);
            btnViewMaterial=(Button)view.findViewById(R.id.btnViewMaterial);
        }
    }
}
