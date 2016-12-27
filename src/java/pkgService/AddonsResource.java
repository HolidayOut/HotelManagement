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
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Account;
import pkgModel.Addon;
import pkgModel.AddonWrapper;
import pkgModel.Database;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("addons")
public class AddonsResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of AddonsResource
     */
    public AddonsResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.AddonsResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Addon> getAddOns() throws Exception{
       List<Addon> ret = null;
        try{
            ret =  Database.getInstance().getAllAddons();
        }
        catch(Exception ex)
        {
            Logger.getLogger(AddonsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return ret;
    }

    /**
     * PUT method for updating or creating an instance of AddonsResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void orderAddOn(AddonWrapper a) throws Exception
    {
        try{
            System.out.println("**xx** "+a);
            Database.getInstance().orderAddOn(a);
        }
        catch(Exception ex)
        {
            Logger.getLogger(AddonsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        //return a;
    }
}
