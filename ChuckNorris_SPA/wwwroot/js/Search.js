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
			}
		},

		Search: function (category) {
			var parameters = {
				joke: category,
				profile: $('#txtSearch').text()
			};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/search',
				data: parameters,
				type: 'GET',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {
					// get the Categories

					var joke = data.joke.result;
					var person = data.profile.result;

					$("#category").html(data.joke.origin);
					
					$.each(joke, function (key, x) {
						
						
						$("#created_at").append(`${x.created_At}<br/>`);
						$("#icon_url").append(`${x.icon_Url}<br/>`);
						$("#updated_at").append(`${x.updated_at}<br/>`);
						$("#id").append(`${x.id} <br/>`);
						$("#value").append(`${x.value} <br/>`);

						$.each(x.categories, function (key, value) {
							$("#jokeCategory").append(`${value}<br/>`);
						});
					});

					$("#origin").html(data.profile.origin);
	
					$("#birth_Year").html(person.birth_Year);
					$("#eye_Color").html(person.eye_Color);
					$("#films").html(person.films);
					$("#gender").html(person.gender);
					$("#hair_Color").html(person.hair_Color);
					$("#height").html(person.height);
					$("#homeworld").html(person.homeworld);
					$("#mass").html(person.mass);
					$("#name").html(person.name);

					
					
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
				joke: category,
				profile: $('#txtSearch').val()
			};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/search',
				/*data: { parameters },*/
				data: JSON.stringify({
					"profile": $('#txtSearch').val(),
					"joke": category
				}),
				type: 'POST',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {
					// get the Categories

					var joke = data.joke.result;
					var person = data.profile.results[0];

					$("#category").html(data.joke.origin);

					$.each(joke, function (key, x) {


						$("#created_at").append(`${x.created_At}<br/>`);
						$("#icon_url").append(`${x.icon_Url}<br/>`);
						$("#updated_at").append(`${x.updated_at}<br/>`);
						$("#id").append(`${x.id} <br/>`);
						$("#value").append(`${x.value} <br/>`);

						$.each(x.categories, function (key, value) {
							$("#jokeCategory").append(`${value}<br/>`);
						});
					});

					$("#origin").html(data.profile.origin);

					$("#birth_Year").html(person.birth_Year);
					$("#eye_Color").html(person.eye_Color);
					$("#films").html(person.films);
					$("#gender").html(person.gender);
					$("#hair_Color").html(person.hair_Color);
					$("#height").html(person.height);
					$("#homeworld").html(person.homeworld);
					$("#mass").html(person.mass);
					$("#name").html(person.name);
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
		Initialise: function (applicationKey, email, category) {
			api.functions.SetConfig(applicationKey, email);
			api.Search(category);
		},
		Search: function (category) {
			api.SearchRandomJoke(category);
		}
	};

	return {
		Functions: functions
	};

})(jQuery);
