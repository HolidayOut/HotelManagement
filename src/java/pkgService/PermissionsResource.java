/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.sql.PreparedStatement;
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
import pkgModel.Permission;
/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("permissions")
public class PermissionsResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of PermissionsResource
     */
    public PermissionsResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.PermissionsResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Permission> getAllPermissionsByRole(@QueryParam("id_role")int id_role) throws Exception {
       List<Permission> ret = null;
        try{
            ret = Database.getInstance().getAllPermissionsByRole(id_role);
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return ret;
    }

    /**
     * PUT method for updating or creating an instance of PermissionsResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    /*
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void addPermissionToRole(int id_role, int id_permission) throws Exception
    {
        try{
            Database.getInstance().addPermissionsToRole(id_role, id_permission);
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    public void removePermissionsFromRole(int id_role, int id_permission) throws Exception
    {
        try{
            Database.getInstance().removePermissionsFromRole(id_role, id_permission);
        }
        catch(Exception ex) {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    */
    @Path("allpermissions")
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Permission> getAllPermissions () throws Exception
    {
        List<Permission> ret = null;
        try{
            ret = Database.getInstance().getAllPermissions();
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return ret;
    }
}
