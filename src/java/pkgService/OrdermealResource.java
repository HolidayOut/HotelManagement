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
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.MealOrderWrapper;
import pkgModel.MealWrapper;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("ordermeal")
public class OrdermealResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of OrdermealResource
     */
    public OrdermealResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.OrdermealResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<MealOrderWrapper> getMealOrders() throws Exception{
        try {
            return  Database.getInstance().getAllMealOrders();
        } catch (Exception ex) {
            Logger.getLogger(OrdermealResource.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    /**
     * PUT method for updating or creating an instance of OrdermealResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void insertMealOrder(MealWrapper w) throws Exception 
    {
        try{
            Database.getInstance().insertListOfMealsToStay(w);
        }
        catch(Exception ex)
        {
            Logger.getLogger(OrdermealResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    public void deleteMealOrder(MealOrderWrapper w) throws Exception 
    {
        try{
            System.out.println("aaaa");
            Database.getInstance().deleteOrderWrapper(w);
        }
        catch(Exception ex)
        {
            Logger.getLogger(OrdermealResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
}
