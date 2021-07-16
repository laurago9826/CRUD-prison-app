/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Classok;

import java.io.Serializable;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;


/**
 *
 * @author Hp Probook 440 G5
 */
@XmlRootElement
public class FegyencIdo implements Serializable {

    /**
     * @param fegyencnev the fegyencnev to set
     */
    public void setFegyencnev(String fegyencnev) {
        this.fegyencnev = fegyencnev;
    }

    /**
     * @param fegyenc_id the fegyenc_id to set
     */
    public void setFegyenc_id(String fegyenc_id) {
        this.fegyenc_id = fegyenc_id;
    }

    /**
     * @param letoltendo_ido the letoltendo_ido to set
     */
    public void setLetoltendo_ido(int letoltendo_ido) {
        this.letoltendo_ido = letoltendo_ido;
    }

    @XmlElement(name="nev")
    public String fegyencnev;
    @XmlElement(name="azonosito")
    public String fegyenc_id;
    @XmlElement
    public int ev;
    @XmlElement
    public int letoltendo_ido;
    
    
}
