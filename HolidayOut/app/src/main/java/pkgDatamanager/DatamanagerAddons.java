package pkgDatamanager;

import java.util.ArrayList;
import java.util.List;

import pkgData.Addon;

/**
 * Created by Andreas Druml on 22.12.2016.
 */
public class DatamanagerAddons {

    private static DatamanagerAddons dm = null;
    private List<Addon> listAddons = null;

    private DatamanagerAddons() {
        //TODO get Addons from Webservice
        listAddons = new ArrayList<Addon>();
        listAddons.add(new Addon(1, "Finnische Sauna", 11, "Ein entspannender Tag in unserer Finnischen Sauna"));
        listAddons.add(new Addon(2, "Kletterkurs", 25, "Ein ausgebildeter Alpinist wird mit Ihnen die wichtigste Theorie und die wichtigsten Knoten besprechen, dann gehts zur Felswand 5 gehminuten vom Hotel"));
        listAddons.add(new Addon(3, "Kasino Abend", 50, "Eintritt in den VIP Bereich unseres hotelinternen Kasinos"));
        listAddons.add(new Addon(4, "Kinderbereuung", 5, "Unsere ausgebildeten Kindergärtnerinnen werden einen Nachmittag mit Ihren Kindern in unserem Spieleparadies verbringen"));
    }

    public static DatamanagerAddons getInstance() {
        if(dm == null) {
            dm = new DatamanagerAddons();
        }
        return dm;
    }

    public List<Addon> getAllAddons() {
        return listAddons;
    }

    public void bookAddon(int ID_Addon) {
        //TODO Book in Webservice
    }

    public Addon getItemByIndex(int index) {
        return listAddons.get(index);
    }

}
