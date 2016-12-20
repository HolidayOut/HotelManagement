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
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Role;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("roles")
public class RolesResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of RolesResource
     */
    public RolesResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.RolesResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Role getRoleByUsername(@QueryParam ("u") String u) throws Exception {
        Role r = null;
        try{
           r = Database.getInstance().getRoleByUsername(u);
       }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return r;
    }

    /**
     * PUT method for updating or creating an instance of RolesResource
     * @param content representation for the resource
     */
    @Path("rolebyid")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Role getRoleById(@QueryParam("id")int id) throws Exception
    {
         Role r = null;
        try{
           r = Database.getInstance().getRoleByID(id);
       }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return r;
    }
    
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @Path("allroles")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Role> getAllRoles() throws Exception
    {
        List<Role> temp = null;
        try{
            temp = Database.getInstance().getAllRoles();
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return temp;
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void insertRole(String roleName) throws Exception
    {
        try{
           Database.getInstance().insertRole(roleName);
        }
        catch(Exception e)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, e);
            throw e;
        }
    }
    
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    public void removeRole(int id_role) throws Exception
    {
        try{
            Database.getInstance().removeRoleById(id_role);
        }
        catch(Exception e)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, e);
            throw e;
        }
    }
    
}
