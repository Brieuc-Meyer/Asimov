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
                res.json(data)
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
                res.json(data)
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
                res.json("Matière ajoutée avec succès")
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
                res.json("Matière supprimée avec succès")
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
                res.json("Matière modifiée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },
    
    async afficherClasses(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAfficherClasses(req)
            
            if (data) {
                //console.log(data)
                res.json(data)
            }

        } catch (error) {
            console.log(error)
        }


    },
    async ajouterClasse(req, res) {

        try {
        /**
         * @param req contient le param id a suprimmer
         */
            let data = await modelProviseurs.modelAjouterClasse(req)
            
            if (data) {
                //console.log(data)
                res.json("Classe ajoutée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },


    async supprimerClasse(req, res) {

        try {
            /**
             * @param req contient les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelSupprimerClasse(req)
            if (data ) {
                //console.log(data)
                res.json("Classe supprimée avec succès")
            }
        } catch (error) {
            console.log(error)
        }


    },

    async modifClasse(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelModifClasse(req)
            
            if (data) {
                //console.log(data)
                res.json("Classe modifiée avec succès")
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
                res.json(data)
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
                res.json("Professeur ajouté avec succès")
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
                res.json("Professeur modifié avec succès")
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
                res.json("Professeur suprimmé avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },

    async assignerClasse(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAssignerClasse(req)
            
            if (data) {
                //console.log(data)
                res.json("Classe asignée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },

    async suprimmerAsignationClasse(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelSuprimmerAssignationClasse(req)
            
            if (data) {
                //console.log(data)
                res.json("Classe désasignée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },

    async assignerMatiere(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelAssignerMatiere(req)
            
            if (data) {
                //console.log(data)
                res.json("Matière asignée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },
    
    async suprimmerAsignationMatiere(req, res) {

        try {
            /**
             * @param req envoie à la BDD les data de la mutuelle a modifier
             */
            let data = await modelProviseurs.modelSuprimmerAssignationMatiere(req)
            
            if (data) {
                //console.log(data)
                res.json("Matière désasignée avec succès")
            }

        } catch (error) {
            console.log(error)
        }


    },

}