package bsd.holidayout;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

public class MenuActivity extends AppCompatActivity implements android.view.View.OnClickListener{

    Button btnOrder;
    Button btnCancel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        getAllGuiElements();
        registerEventHandlers();
    }

    private void registerEventHandlers() {
        btnOrder.setOnClickListener(this);
        btnCancel.setOnClickListener(this);

    }

    private void getAllGuiElements() {
        btnOrder = (Button) this.findViewById(R.id.btnOrder);
        btnCancel = (Button) this.findViewById(R.id.btnCancel);
    }

    @Override
    public void onClick(View v) {
        if(v == btnCancel) {
            Intent restaurantOrderIntent = new Intent(this, RestaurantOrderActivity.class);
            startActivity(restaurantOrderIntent);
        }
    }
}
