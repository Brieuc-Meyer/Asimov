/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
*/

//importer les models d'accès aux donnés (requetes SQL)
const modelProviseurs = require('../models/modelProviseurs.js')



module.exports = {

    /**
    * méthodes qui envoient la @req au @modelProviseurs () , sans bloquer le thread principal.
    * le resultat @res , est d'afficher les données contenues dans @data et/ou de rediriger après une opération réussi vers la BDD .
    */

    async afficherTousLesEleves(req, res) {

        try {
            let data = await modelProviseurs.modelAfficherTousLesEleves(req)
           
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },


    async afficherToutesLesMatieres(req, res) {

        try {
            /**
             * @param req contient les data du params du dom
             */
            let data = await modelProviseurs.modelAfficherToutesLesMatieres(req)
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },

    async ajouterMatiere(req, res) {

        try {
        /**
         * @param req contient le param id a suprimmer
         */
            let data = await modelProviseurs.modelAjouterMatiere(req)
            
            if (data) {
                //console.log(data)
                res.status(200)
            }

        } catch (error) {
            console.log(error)
        }


    },


    async supprimerMatiere(req, res) {

        try {
            /**
             * @param req contient les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelSupprimerMatiere(req)
            if (data ) {
                //console.log(data)
                res.status(200)
            }
        } catch (error) {
            console.log(error)
        }


    },

    async afficherModifMatiere(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAfficherModifMatiere(req)
            
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },
    async modifMatiere(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelModifMatiere(req)
            
            if (data) {
                //console.log(data)
                res.status(200)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async afficherProfesseurs(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAfficherProfesseurs(req)
            
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async ajouterPersonnel(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAjouterPersonnel(req)
            
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async afficherModifPersonnel(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAfficherModifPersonnel(req)
            
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async modifPersonnel(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelModifPersonnel(req)
            
            if (data) {
                //console.log(data)
                res.status(200)
            }

        } catch (error) {
            console.log(error)
        }


    },

    async supprimerPersonnel(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelSupprimerPersonnel(req)
            
            if (data) {
                //console.log(data)
                res.status(200)
            }

        } catch (error) {
            console.log(error)
        }


    },

}