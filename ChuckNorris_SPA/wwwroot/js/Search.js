var Search = (function ($) {

	var api = {
		config: {
			applicationKey: '',
			account: ''
		},

		functions: {
			SetConfig: function (key, email) {
				api.config = {
					applicationKey: key,
					account: email
				};
			},

			SearchOption: function (key) {

				let searchKey = key.split("#");
				if (searchKey != null && searchKey[0] == "joke") {
					Search.Functions.SearchJoke(searchKey[1]);
				} else if (searchKey != null && searchKey[0] == "people") {
					Search.Functions.SearchPeople(searchKey[1]);
				}
			}
		},

		SearchPeople: function (category) {
			var parameters = {
				input: category
			};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/searchPeople',
				data: parameters,
				type: 'GET',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {
					//$("#categoriesDiv2").show();
					//$("#categoriesDiv").hide();
					if (data != null & data.results.length > 0) {
						var person = data.results[0];

						$("#origin").html(data.origin);

						$("#birth_Year").html(person.birth_Year);
						$("#eye_Color").html(person.eye_Color);
						
						$("#gender").html(person.gender);
						$("#hair_Color").html(person.hair_Color);
						$("#height").html(person.height);
						$("#homeworld").html(`<a href="${person.homeworld}">${person.homeworld}</a><br/>`);
						$("#url").html(`<a href="${person.url}">${person.url}</a><br/>`);
						$("#mass").html(person.mass);
						$("#name").html(person.name);

						$.each(person.films, function (key, value) {
							$("#films").append(`<a href="${value}">${value}</a><br/>`);
						});

						$.each(person.species, function (key, value) {
							$("#species").append(`<a href="${value}">${value}</a><br/>`);
						});

						$.each(person.vehicles, function (key, value) {
							$("#vehicles").append(`<a href="${value}">${value}</a><br/>`);
						});

						$.each(person.starships, function (key, value) {
							$("#starships").append(`<a href="${value}">${value}</a><br/>`);
						});
                    }
					
				},
				complete: function (data) {

				},
				error: function (data) {
					var t = data;
				}
			});
		},

		SearchRandomJoke: function (category) {
			var parameters = {
				input: category
			};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/searchJoke',
				data: parameters,
				type: 'GET',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {
					// get the Categories
					//$("#categoriesDiv2").hide();
					//$("#categoriesDiv").show();
					var joke = data.result;

					$("#category").html(data.origin);

					$.each(joke, function (key, x) {


						/*$("#created_at").append(`${x.created_At}<br/>`);*/
						/*$("#icon_url").append(`<img src="${x.icon_Url}" alt=""><br/>`);*/
					/*	$("#url").append(`<a href="${x.url}"><a/><br/>`);*/
						//$("#updated_at").append(`${x.updated_at}<br/>`);
						//$("#id").append(`${x.id} <br/>`);
						$("#value").append(`<a href="${x.url}">${x.value}<a/><br/>`);

						$.each(x.categories, function (key, value) {
							$("#jokeCategory").append(`${value}<br/>`);
						});
					});
				},
				complete: function (data) {

				},
				error: function (data) {
					var t = data;
				}
			});
		}
		
	};

	var functions = {
		Initialise: function (applicationKey, email, searchKey) {
			api.functions.SetConfig(applicationKey, email);
			api.functions.SearchOption(searchKey);
		},
		SearchPeople: function (people) {
			api.SearchPeople(people);
        }
		,
		SearchJoke: function (category) {
			api.SearchRandomJoke(category);
		}
	};

	return {
		Functions: functions
	};

})(jQuery);
