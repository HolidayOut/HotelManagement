package bsd.holidayout;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import pkgData.Account;
import pkgDatamanager.Credentials;
import pkgDatamanager.DatamanagerLogin;

public class LoginActivity extends AppCompatActivity implements android.view.View.OnClickListener {

    Button btnLogin;
    EditText txtUsername;
    EditText txtPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        getAllGuiComponents();
        registerEventhandlers();
    }

    private void registerEventhandlers() {
        btnLogin.setOnClickListener(this);
    }

    private void getAllGuiComponents() {
        btnLogin = (Button) this.findViewById(R.id.btnLogin);
        txtUsername = (EditText) this.findViewById(R.id.txtUsername);
        txtPassword = (EditText) this.findViewById(R.id.txtPassword);
    }

    @Override
    public void onClick(View v) {
        if(v == btnLogin) {
            Account acc = new Account();
            acc.setUsername(txtUsername.getText().toString());
            acc.setPassword(txtPassword.getText().toString());

            int role_id = DatamanagerLogin.getInstance().checkLogin(acc);

            if(role_id != -2){ //-2 = incorrect username or password
                if(role_id == 2) { //2 = guest
                    Intent overviewIntent = new Intent(this, OverviewActivity.class);
                    Credentials.getInstance().setUsername(txtUsername.getText().toString());
                    startActivity(overviewIntent);
                }
            }
            else {
                Toast.makeText(getApplicationContext(), "Incorrect username or password!",   Toast.LENGTH_LONG).show();
            }


        }
    }
}
