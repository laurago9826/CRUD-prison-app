/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Classok;

import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Hp Probook 440 G5
 */
@XmlRootElement(name="letoltendo_idok")
public class FegyencidokXMLbe {
    @XmlElement(name ="fegyenc")
    public List<FegyencIdo> fegyencidok;
}
