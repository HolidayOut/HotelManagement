package pkgData;

/**
 * Created by Andreas Druml on 22.12.2016.
 */
public class Addon {
    private int ID_Addon;
    private String name;
    private int price;
    private String description;

    public Addon() {

    }

    public Addon(int _ID_Addon, String _name, int _price, String _description) {
        this.ID_Addon = _ID_Addon;
        this.name = _name;
        this.price = _price;
        this.description = _description;
    }

    public int getID_Addon() {
        return ID_Addon;
    }

    public void setID_Addon(int ID_Addon) {
        this.ID_Addon = ID_Addon;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @Override
    public String toString() {
        return name + "  €" + price;
    }
}
