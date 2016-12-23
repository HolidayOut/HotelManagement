package bsd.holidayout;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainCourseActivity extends AppCompatActivity implements android.view.View.OnClickListener{

    Button btnNext;
    Button btnSkip;
    Button btnCancel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_course);

        getAllGuiElements();
        registerEventHandlers();
    }

    private void registerEventHandlers() {
        btnNext.setOnClickListener(this);
        btnSkip.setOnClickListener(this);
        btnCancel.setOnClickListener(this);
    }

    private void getAllGuiElements() {
        btnNext = (Button) this.findViewById(R.id.btnNext);
        btnSkip = (Button) this.findViewById(R.id.btnSkip);
        btnCancel = (Button) this.findViewById(R.id.btnCancel);
    }

    @Override
    public void onClick(View v) {
        if(v == btnNext) {
            Intent dessertIntent = new Intent(this, DessertActivity.class);
            //dessertIntent.putExtra();
            startActivity(dessertIntent);
        }
        else if(v == btnSkip) {
            Intent dessertIntent = new Intent(this, DessertActivity.class);
            startActivity(dessertIntent);
        }
        else if(v == btnCancel) {
            Intent restaurantOrderIntent = new Intent(this, RestaurantOrderActivity.class);
            startActivity(restaurantOrderIntent);
        }
    }
}
