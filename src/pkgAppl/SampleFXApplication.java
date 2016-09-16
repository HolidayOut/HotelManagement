package pkgAppl;

import javafx.application.*;
import javafx.stage.Stage;
import javafx.scene.*;
import javafx.fxml.*;

public class SampleFXApplication extends Application {

	@Override
	public void start(Stage primaryStage) throws Exception {
		Parent rootFrame = FXMLLoader.load(getClass().getResource("SampleFX.fxml"));
		
		Scene scene = new Scene(rootFrame);
		
		primaryStage.setScene(scene);
		primaryStage.show();
		
	}
	
	public static void main(String[] args) {
		launch(args);
	}

}
