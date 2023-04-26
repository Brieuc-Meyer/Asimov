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
    async afficherElevesUnProf(req, res) {

        try {
            let data = await modelProfesseurs.modelAfficherElevesUnProf(req)
           
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },
    async afficherNotesUnEleve(req, res) {

        try {
            let data = await modelProfesseurs.modelAfficherNotesUnEleve(req)
           
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },

    async ajouterEleve(req, res) {

        try {
            /**
             * @param req contient les data du params du dom
             */
            let data = await modelProfesseurs.modelAjouterEleve(req)
            if (data) {
                res.json("Elève ajouté avec succés")
            }
        } catch (error) {
            console.log(error)
        }


    },


    async supprimerEleve(req, res) {

        try {
            /**
             * @param req contient le param id a suprimmer
             */
            let data = await modelProfesseurs.modelSupprimerEleve(req)
            if (data) {
                res.json("Elève supprimé avec succés")
            }
        } catch (error) {
            console.log(error)
        }


    },
    async afficherModifEleve(req, res) {

        try {
            /**
             * @param req contient les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelafficherModifEleve(req)
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },


    async modifEleve(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelmodifEleve(req)
            if (data) {
                //console.log(data)
                res.json("Modification de l'élève avec succés")
            }

        } catch (error) {
            console.log(error)
        }


    },
    async afficherMatieresProf(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelAfficherMatieresProf(req)
            if (data) {
                //console.log(data)
                res.json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async afficherClassesProf(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelAfficherClassesProf(req)
            if (data) {
                //console.log(data)
                res.json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async ajouterNote(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelAjouterNote(req)
            if (data) {
                //console.log(data)
                res.json("Note ajoutée avec succés")
            }

        } catch (error) {
            console.log(error)
        }


    },
    
    
    async afficherModifNote(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelAfficherModifNote(req)
            if (data) {
                //console.log(data)
                res.status(200).json(data)

            }

        } catch (error) {
            console.log(error)
        }


    },

    async modifNote(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelModifNote(req)
            if (data) {
                //console.log(data)
                res.json("Note modifiée avec succés")

            }

        } catch (error) {
            console.log(error)
        }


    },
    
    
    async supprimerNote(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data du medicament a modifier
             */
            let data = await modelProfesseurs.modelSupprimerNote(req)
            if (data) {
                //console.log(data)
                res.json("Note supprimé avec succés")

            }

        } catch (error) {
            console.log(error)
        }


    },
    

}

