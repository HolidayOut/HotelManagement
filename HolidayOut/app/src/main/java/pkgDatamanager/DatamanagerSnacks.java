package pkgDatamanager;

import java.util.ArrayList;
import java.util.List;

import pkgData.Snack;
import pkgDatahelper.SnackHelper;

/**
 * Created by Andreas Druml on 22.12.2016.
 */
public class DatamanagerSnacks {

    private static DatamanagerSnacks dm = null;
    private List<String> listCategories = null;
    private List<Snack> listSnacks = null;


    private DatamanagerSnacks() {
        listCategories = new ArrayList<String>();
        listCategories.add("Drinks");
        listCategories.add("Sweets");
        listCategories.add("Snacks");

        //TODO get Snacks from Webservice
        listSnacks = new ArrayList<Snack>();
        listSnacks.add(new Snack(1, 1, "Gösser 0.5", 4));
        listSnacks.add(new Snack(2, 1, "Flasche weiß", 23));
        listSnacks.add(new Snack(3, 1, "Flasche rot", 23));
        listSnacks.add(new Snack(4, 1, "Mineralwasser 0.5", 3));
        listSnacks.add(new Snack(5, 1, "Flasche Champagner", 90));
        listSnacks.add(new Snack(6, 2, "Chips", 4));
        listSnacks.add(new Snack(7, 2, "Erdnüsse", 4));
        listSnacks.add(new Snack(8, 2, "Haribo", 3));
        listSnacks.add(new Snack(9, 2, "Kekse", 4));
        listSnacks.add(new Snack(10, 3, "Toast", 8));
        listSnacks.add(new Snack(11, 3, "Frankfurter", 9));
    }

    public static DatamanagerSnacks getInstance() {
        if(dm == null) {
            dm = new DatamanagerSnacks();
        }
        return dm;
    }

    public List<String> getAllCategories() {
        return listCategories;
    }

    public List<Snack> getAllDrinks() {
        List<Snack> listDrinks = new ArrayList<Snack>();
        for(Snack s : listSnacks) {
            if(s.getSnackType() == 1) { //1 = drinks
                listDrinks.add(s);
            }
        }
        return listDrinks;
    }

    public List<Snack> getAllSweets() {
        List<Snack> listSweets = new ArrayList<Snack>();
        for(Snack s : listSnacks) {
            if(s.getSnackType() == 2) { //2 = sweets
                listSweets.add(s);
            }
        }
        return listSweets;
    }

    public List<Snack> getAllSnacks() {
        List<Snack> listS = new ArrayList<Snack>();
        for(Snack s : listSnacks) {
            if(s.getSnackType() == 3) { //3 = Snacks
                listS.add(s);
            }
        }
        return listS;
    }

    public void orderShoppingCart(List<SnackHelper> shoppingCart) {
        //TODO Order with Webservice
    }
}
