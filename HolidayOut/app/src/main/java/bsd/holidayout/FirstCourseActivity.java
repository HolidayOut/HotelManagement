package bsd.holidayout;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

public class FirstCourseActivity extends AppCompatActivity implements android.view.View.OnClickListener{

    Button btnNext;
    Button btnSkip;
    Button btnCancel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first_course);

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
            Intent mainCourseIntent = new Intent(this, MainCourseActivity.class);
            //mainCourseIntent.putExtra();
            startActivity(mainCourseIntent);
        }
        else if(v == btnSkip) {
            Intent mainCourseIntent = new Intent(this, MainCourseActivity.class);
            startActivity(mainCourseIntent);
        }
        else if(v == btnCancel) {
            Intent restaurantOrderIntent = new Intent(this, RestaurantOrderActivity.class);
            startActivity(restaurantOrderIntent);
        }
    }
}
