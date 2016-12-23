package bsd.holidayout;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

import pkgDatamanager.Credentials;

public class OverviewActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    TextView lblName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_overview);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        getAllGuiElements();
        lblName.setText(Credentials.getInstance().getName());

    }

    private void getAllGuiElements() {
        lblName = (TextView)this.findViewById(R.id.lblName);
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.overview, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_overview) {
            //this activity
        } else if (id == R.id.nav_addons) {
            Intent addonsIntent = new Intent(this, AddonsActivity.class);
            //addonsIntent.putExtra();
            startActivity(addonsIntent);
        } else if (id == R.id.nav_room_service) {
            Intent roomServiceIntent = new Intent(this, RoomServiceActivity.class);
            //roomServiceIntent.putExtra();
            startActivity(roomServiceIntent);
        } else if (id == R.id.nav_restaurant_order) {
            Intent restaurantOrderIntent = new Intent(this, RestaurantOrderActivity.class);
            //roomServiceIntent.putExtra();
            startActivity(restaurantOrderIntent);
        }
        else if(id == R.id.nav_logout) {
            Intent loginIntent = new Intent(this, LoginActivity.class);
            //loginIntent.putExtra();
            startActivity(loginIntent);
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
