package pkgData;

/**
 * Created by Andreas Druml on 22.12.2016.
 */
public class Snack {
    private int ID_Snack;
    private int snackType;
    private String snackName;
    private int price;

    public Snack() {
    }

    public Snack(int ID_Snack, int snackType, String snackName, int price) {
        this.ID_Snack = ID_Snack;
        this.snackType = snackType;
        this.snackName = snackName;
        this.price = price;
    }

    public int getID_Snack() {
        return ID_Snack;
    }

    public void setID_Snack(int ID_Snack) {
        this.ID_Snack = ID_Snack;
    }

    public int getSnackType() {
        return snackType;
    }

    public void setSnackType(int snackType) {
        this.snackType = snackType;
    }

    public String getSnackName() {
        return snackName;
    }

    public void setSnackName(String snackName) {
        this.snackName = snackName;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return  snackName + "  €" + price;

    }
}
