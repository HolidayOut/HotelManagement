
package pkgService;

import java.util.Set;
import javax.ws.rs.core.Application;

/**
 *
 * @author John_13
 */
@javax.ws.rs.ApplicationPath("webresources")
public class ApplicationConfig extends Application {

    @Override
    public Set<Class<?>> getClasses() {
        Set<Class<?>> resources = new java.util.HashSet<>();
        addRestResourceClasses(resources);
        return resources;
    }

    /**
     * Do not modify addRestResourceClasses() method.
     * It is automatically populated with
     * all resources defined in the project.
     * If required, comment out calling this method in getClasses().
     */
    private void addRestResourceClasses(Set<Class<?>> resources) {
        resources.add(pkgService.GenericResource.class);
        resources.add(pkgService.GuestsResource.class);
        resources.add(pkgService.MealsResource.class);
        resources.add(pkgService.StaysResource.class);
        resources.add(pkgService.ValidateaccResource.class);
    }
    
}

 
