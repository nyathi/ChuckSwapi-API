var ListOfPeople = (function ($) {

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

		ListOfPeople: function () {
			var parameters = {};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/swapi/people',
				data: parameters,
				type: 'GET',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {

					var person = data.results;
					$.each(person, function (key, value) {
						$("#peopleDiv").append(`<a href="/Search?people=${value.name}">${value.name}</a><br/>`);
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
		Initialise: function (applicationKey, email) {
			api.functions.SetConfig(applicationKey, email);
			api.ListOfPeople();
		}
	};

	return {
		Functions: functions
	};

})(jQuery);
