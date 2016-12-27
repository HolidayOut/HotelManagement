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
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Employee;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("employees")
public class EmployeesResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of EmployeesResource
     */
    public EmployeesResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.EmployeesResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Employee> getXml() throws Exception {
        List<Employee> employees = null;
        try{
            employees = Database.getInstance().getEmployees();
        }
        catch(Exception ex)
        {
            Logger.getLogger(EmployeesResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return employees;
    }

    /**
     * PUT method for updating or creating an instance of EmployeesResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void updateEmp(Employee e) throws Exception{
        try{
            Database.getInstance().updateEmployee(e);
        }
        catch(Exception ex)
        {
            Logger.getLogger(EmployeesResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void addEmpl(Employee e) throws Exception 
    {
        try{
            Database.getInstance().insertEmployee(e);
        }
        catch(Exception ex)
        {
            Logger.getLogger(EmployeesResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @DELETE
    @Path("/{username}")
    public void delEmpl(@PathParam("username") String username) throws Exception 
    {
        try{
            Database.getInstance().deleteEmployee(username);
        }
        catch(Exception ex)
        {
            Logger.getLogger(EmployeesResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
}
