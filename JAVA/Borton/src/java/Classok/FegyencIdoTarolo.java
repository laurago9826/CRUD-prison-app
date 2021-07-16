/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Classok;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 *
 * @author Hp Probook 440 G5
 */
public class FegyencIdoTarolo {

    private List<FegyencIdo> idotarolo = new ArrayList<FegyencIdo>();
    FegyencIdo minta;

    public FegyencIdoTarolo(FegyencIdo minta) {
        this.minta = minta;
        this.idotarolo.add(minta);
        tobbi_legeneral();
    }

    private void tobbi_legeneral() {
        Random r = new Random();

        String fegyencnev = this.minta.fegyencnev;
        String fegyenc_id = this.minta.fegyenc_id;
        int elozo_peldany_ev = this.minta.ev;
        int elozo = this.minta.letoltendo_ido;

        int i = 0;
        while (i < 4) {
            i = i + 1;
            this.getIdotarolo().add(new FegyencIdo());
        }
        for (FegyencIdo f : idotarolo) {
            f.fegyenc_id = fegyenc_id;
            f.fegyencnev = fegyencnev;
            int mostani =0;
            if (elozo>0 ) {
                do{
                mostani = elozo -2 + r.nextInt(4) - r.nextInt(4);
                }while(mostani<=0);
            }
            else 
                mostani = 0;
            f.letoltendo_ido = elozo;
            f.ev = elozo_peldany_ev;
            
            elozo = mostani;
            elozo_peldany_ev = elozo_peldany_ev + 1;

        }
    }

    /**
     * @return the idotarolo
     */
    public List<FegyencIdo> getIdotarolo() {
        return idotarolo;
    }

}
