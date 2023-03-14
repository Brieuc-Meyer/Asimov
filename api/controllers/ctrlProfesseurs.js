/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
*/

//importer les models d'accès aux donnés (requetes SQL)
let modelProfesseurs = require('../models/modelProfesseurs.js')

module.exports = {    
    /**
    * méthodes qui envoient la @req au @modelProfesseurs () , sans bloquer le thread principal.
    * le resultat @res , est d'afficher les données contenues dans @data et/ou de rediriger après une opération réussi vers la BDD .
    */
    async afficherEleves(req, res) {

        try {
            let data = await modelProfesseurs.modelAfficherMedicaments()
            let data2 = await modelProfesseurs.modelbesoinsTotauxMedicaments()

            if (data) {
                //console.log(data)
                res.status(200).json(data,data2)
            }
        } catch (error) {
            console.log(error)
        }


    },

    async ajouterEleve(req, res) {

        try {
            /**
             * @param req contient les data du body du dom
             */
            let data = await modelProfesseurs.modelAjouterMedicament(req)
            if (data) {
                res.redirect("/medicaments")
            }
        } catch (error) {
            console.log(error)
        }


    },


    async supprimerMedicament(req, res) {

        try {
            /**
             * @param req contient le param id a suprimmer
             */
            let data = await modelProfesseurs.modelSupprimerMedicament(req)
            if (data) {
                res.redirect("/medicaments")
            }
        } catch (error) {
            console.log(error)
        }


    },
    async afficherModifMedicament(req, res) {

        try {
            /**
             * @param req contient les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelafficherModifMedicament(req)
            if (data) {
                //console.log(data)
                res.render("./modifMedicament", { medicament: data })
            }
        } catch (error) {
            console.log(error)
        }


    },


    async modifMedicament(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelmodifMedicament(req)
            if (data) {
                //console.log(data)
                res.redirect("/medicaments")
            }

        } catch (error) {
            console.log(error)
        }


    }

}

