/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servletek;

import Classok.FegyencIdo;
import Classok.FegyencIdoTarolo;
import Classok.FegyencidokXMLbe;
import java.awt.Desktop;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.URI;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

/**
 *
 * @author Hp Probook 440 G5
 */
@WebServlet(name = "Generalas", urlPatterns = {"/Generalas"})
public class Generalas extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        try {
            
            response.setContentType("text/xml;charset=UTF-8");
            
            //HttpSession session = request.getSession(true);
            String fegyenc= request.getParameter("fegyenc");
            String fegyenc_id= request.getParameter("fegyenc_id");
            String letoltendo_ido= request.getParameter("letoltendo_ido");
            
            FegyencIdo fegyencido= new FegyencIdo();
            fegyencido.fegyenc_id= fegyenc_id;
            fegyencido.fegyencnev= fegyenc;
            fegyencido.letoltendo_ido=Integer.parseInt(letoltendo_ido);
            fegyencido.ev=2014;
            
            FegyencIdoTarolo osszes = new FegyencIdoTarolo(fegyencido);
            FegyencidokXMLbe fajlba = new FegyencidokXMLbe();
           
            
            PrintWriter out = response.getWriter();
            
            fajlba.fegyencidok= osszes.getIdotarolo();
            
            JAXBContext jaxbContext = JAXBContext.newInstance(FegyencidokXMLbe.class);
            Marshaller jaxbMarshaller = jaxbContext.createMarshaller();

            jaxbMarshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
            jaxbMarshaller.marshal(fajlba, out);
            
            
            
            
            
            
            
            //try {
                //fk.Kezel(osszes);
            //} catch (InterruptedException ex) {
              //  throw new IOException();
            //};
            
           // request.getRequestDispatcher(fk.url.toString()).forward(request, response);
            
            //try {
               // Desktop desktop = java.awt.Desktop.getDesktop();
               // URI oURL = new URI(fk.url.toString());
               // desktop.browse(oURL);
           // } catch (Exception e) {
            //    e.printStackTrace();
           // }
            
            //if (url != null) {
            //   System.out.println(url);
            //response.sendRedirect(url);
            
            
            //request.getRequestDispatcher("fegyencek.xml").forward(request, response);
        } catch (JAXBException ex) {
            Logger.getLogger(Generalas.class.getName()).log(Level.SEVERE, null, ex);
       }  
        
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
