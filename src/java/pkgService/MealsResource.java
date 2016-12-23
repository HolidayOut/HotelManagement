/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Meal;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("meals")
public class MealsResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of MealsResource
     */
    public MealsResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.MealsResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Meal> getXml() throws Exception {
        try {
            return Database.getInstance().getAllMeals();
        } catch (Exception ex) {
            Logger.getLogger(MealsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        
    }

    /**
     * PUT method for updating or creating an instance of MealsResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putXml(Meal m) throws Exception {
        try{
            Database.getInstance().updateMeal(m);
        }
        catch(Exception ex)
        {
            Logger.getLogger(MealsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    @Path("/{id}")
    public void delete(@PathParam("id")int id) throws Exception{
        try{
            Database.getInstance().removeMeal(id);
        }
        catch(Exception ex)
        {
            Logger.getLogger(MealsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void addMeal(Meal m) throws Exception
    {
        try{
            Database.getInstance().insertMeal(m);
        }
        catch(Exception ex)
        {
            Logger.getLogger(MealsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
}
