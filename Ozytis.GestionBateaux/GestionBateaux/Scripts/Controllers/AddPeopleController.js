app.controller('AddPeople', function($scope) {

	//gere l'etat du bouton de validation de la creation de Personne
	function SetBtnSubmit(etat){
		if (etat) {
			document.getElementById("BtnSubmitPanel").removeAttribute("disabled");
		}else{
			document.getElementById("BtnSubmitPanel").setAttribute("disabled", "disabled");
		}
	}


	var buttonPersonne = document.getElementsByClassName("btnPersonne");

	//Pour chaque Personne afficher
	for (var i = buttonPersonne.length - 1; i >= 0; i--) {

		//creer le bouton de suppression
		var deleteBtn = document.createElement("a");
		deleteBtn.setAttribute("class", "btnDeletePersonne");
		var idPersonne = buttonPersonne[i].getAttribute("identifier");
		deleteBtn.setAttribute("href", "../../People/hiddenAction/Delete/" + idPersonne);
		deleteBtn.innerHTML += "X";
		buttonPersonne[i].appendChild(deleteBtn);


		//evenenement qui affiche le panel en fonction de la Personne selectionnée
		buttonPersonne[i].addEventListener("click", function($this){
			if ($this.target.getAttribute("class") == "btnPersonne") {
				if (document.getElementById("panel").getAttribute("hidden") == "hidden") {
					document.getElementById("panel").removeAttribute("hidden");
					var champsForm = document.getElementById("panelChampsPersonne").getElementsByTagName("input");
					//si bouton de creation de Personne
					if ($this.target.getAttribute("identifier") == "none") {
						champsForm[1].value = "";
						champsForm[2].value = "";
					//sinon c'est un bouton de modification de Personne
					}else{
						var champs = $this.target.getElementsByTagName("span");
						document.getElementById("panelChampsPersonne").children[0].value = $this.target.getAttribute("identifier");
						var champsForm = document.getElementById("panelChampsPersonne").getElementsByTagName("input");
						//actualise la valeur des champs Nom et Prenom en fonction de la personne selectionnée
						for (var i = champs.length - 1; i >= 0; i--) {
							champsForm[i+1].value = champs[i].firstChild.data;
						}	
					}
				}
			}
		});

	}

	//bouton de fermeture du panel
	document.getElementById("btnClosePanel").addEventListener("click", function(){
		document.getElementById("panel").setAttribute("hidden", "hidden");
	});

	var listRoles = document.getElementById("panel").getElementsByClassName("personne");
	var nbRole = 0;
	SetBtnSubmit(false);

	for (var i = listRoles.length - 1; i >= 0; i--) {
		listRoles[i].addEventListener("click", function($this){
			var idTarget = $this.target.id;
			//deselectionne le Role  
			if ($this.target.hasAttribute("selected")) {
				$this.target.removeAttribute("selected");
				var removedInput = document.getElementById(idTarget + "Role");
				document.getElementsByTagName("form")[0].childNodes[1].removeChild(removedInput);
				nbRole--;
				var listRolesSelected = document.getElementsByTagName("form")[0].childNodes[1].getElementsByTagName("input");
				if (nbRole == 0) {
					SetBtnSubmit(false);
				}else{
					//On actualise la liste des Roles chaché d'inputs pour la rendre utilisable
					for (var i = 0; i < listRolesSelected.length; i++) {
						listRolesSelected[i].setAttribute("name", "role[" + i + "]");
					}
				}

			////selectionne le Role 
		} else {
			// input créé
			/*<input hidden="hidden" name="role[nbRole]" id="IdTargetRole" value="IdTarget">*/
			var input = document.createElement("input");
			input.setAttribute("hidden", "hidden");
			input.setAttribute("name", "role[" + (nbRole++) + "]");
			input.setAttribute("id", idTarget + "Role");
			input.setAttribute("value", idTarget);
			document.getElementsByTagName("form")[0].childNodes[1].appendChild(input);
			$this.target.setAttribute("selected", "selected");
			SetBtnSubmit(true);
		}
	});
	}
	

});