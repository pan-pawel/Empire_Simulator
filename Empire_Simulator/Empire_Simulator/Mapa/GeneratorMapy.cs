﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Empire_Simulator
{
    class GeneratorMapy
    {

        private Dictionary<Osada, PictureBox> osadyNaMapie;
        private Dictionary<Handlarz, PictureBox> handlarzeNaMapie;

        public GeneratorMapy()
        {
            osadyNaMapie = new Dictionary<Osada,PictureBox>();
            handlarzeNaMapie = new Dictionary<Handlarz, PictureBox>();
            
        }
        private void dodajTlo(OknoGry okno)
        {
            PictureBox tloMapy = new PictureBox();
            tloMapy.Image = global::Empire_Simulator.Properties.Resources.tloEmpireSimulator1;
            tloMapy.Location = new System.Drawing.Point(1, 3);
            tloMapy.Name = "mapa";
            tloMapy.Size = new System.Drawing.Size(799, 794);
            tloMapy.TabIndex = 0;
            tloMapy.TabStop = false;
            naniesOsadyNaMape(tloMapy);
            naniesHandlarzyNaMape(tloMapy);
            
            okno.Controls.Add(tloMapy);
        }

        private void dodajOsady(Swiat swiat){

            foreach (Osada osada in swiat.pobierzListeOsad())
            {
                osadyNaMapie.Add(osada, new PictureBox());
                PictureBox tempPictureBox = osadyNaMapie[osada];
                tempPictureBox.Image = global::Empire_Simulator.Properties.Resources.osada1;
                tempPictureBox.Location = new System.Drawing.Point(Convert.ToInt32(osada.pozycjaOsady().X), Convert.ToInt32(osada.pozycjaOsady().Y));
                tempPictureBox.Name = "Osada";
                tempPictureBox.Size = tempPictureBox.Image.Size;
                tempPictureBox.BackColor = System.Drawing.Color.Transparent;
                                                
            }                                                                                                          
                 
        }

        private void dodajHandlarzy(Swiat swiat)
        {
            foreach (Handlarz handlarz in swiat.pobierzListeHandlarzy())
            {
                handlarzeNaMapie.Add(handlarz, new PictureBox());
                PictureBox tempPictureBox = handlarzeNaMapie[handlarz];
                tempPictureBox.Image = global::Empire_Simulator.Properties.Resources.handlarz;
                tempPictureBox.Location = new System.Drawing.Point(Convert.ToInt32(handlarz.zwrocPozycje().X), Convert.ToInt32(handlarz.zwrocPozycje().Y));
                tempPictureBox.Name = "Handlarz";
                tempPictureBox.Size = tempPictureBox.Image.Size;
                tempPictureBox.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void naniesOsadyNaMape(PictureBox tloMapy)
        {
            foreach (KeyValuePair<Osada, PictureBox> para in osadyNaMapie)
            {
                tloMapy.Controls.Add(para.Value);
            } 
        }
        private void naniesHandlarzyNaMape(PictureBox tloMapy)
        {
            foreach (KeyValuePair<Handlarz, PictureBox> para in handlarzeNaMapie)
            {
                tloMapy.Controls.Add(para.Value);
            }
        }

        public void generujMape(OknoGry okno, Swiat swiat)
        {
            dodajOsady(swiat);
            dodajHandlarzy(swiat);
            dodajTlo(okno);

        }
        public AktualizatorMapy generujAktualizatoraMapy()
        {
            return new AktualizatorMapy(osadyNaMapie, handlarzeNaMapie);
        }

            
    }

        
            

}

