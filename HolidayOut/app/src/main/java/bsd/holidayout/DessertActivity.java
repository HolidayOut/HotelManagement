package bsd.holidayout;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class DessertActivity extends AppCompatActivity implements android.view.View.OnClickListener {

    Button btnShowMenu;
    Button btnSkip;
    Button btnCancel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dessert);

        getAllGuiElements();
        registerEventHandlers();
    }

    private void registerEventHandlers() {
        btnShowMenu.setOnClickListener(this);
        btnSkip.setOnClickListener(this);
        btnCancel.setOnClickListener(this);
    }

    private void getAllGuiElements() {
        btnShowMenu = (Button) this.findViewById(R.id.btnShowMenu);
        btnSkip = (Button) this.findViewById(R.id.btnSkip);
        btnCancel = (Button) this.findViewById(R.id.btnCancel);
    }

    @Override
    public void onClick(View v) {
        if(v == btnShowMenu) {
            Intent menuIntent = new Intent(this, MenuActivity.class);
            //menuIntent.putExtra();
            startActivity(menuIntent);
        }
        else if(v == btnSkip) {
            Intent menuIntent = new Intent(this, MenuActivity.class);
            //menuIntent.putExtra();
            startActivity(menuIntent);
        }
        else if(v == btnCancel) {
            Intent restaurantOrderIntent = new Intent(this, RestaurantOrderActivity.class);
            startActivity(restaurantOrderIntent);
        }
    }
}
