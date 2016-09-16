package pkgAppl;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.*;

public class SampleFXController implements Initializable {

	@FXML
	private void btn_clickme(ActionEvent _ev) {
		System.out.println("....button clicked: " + _ev.getSource());
	}
	
	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		System.out.println("first thing at first...." + arg0);
                System.out.println("ww");
                
		
	}

}
