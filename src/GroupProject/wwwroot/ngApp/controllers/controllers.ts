namespace GroupProject.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class EventSearchController {
        public eventSearchData;
        public categories;


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get('/api/events')
                .then((response) => {
                    this.eventSearchData = response.data;
                });
            //constructor info used to build the 'search by category' pull-down
            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                });
        }
        

        public readMore(searchData) {

        }


        public Attend(eventId) {
            this.$http.post(`/api/events/attend`, eventId
            )
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);

                });
        }
    }

    export class EventAddController {
        public categories;
        public displayToast($mdToast) {
            var toast = $mdToast.simple()
                .textContent('Your event was added successfully')
                .position('bottom left')
                .hideDelay(5000);

            $mdToast.show(toast);
        };



        // Post the new event to the database
        public addEvent(addEvent) {



            addEvent.admissionPrice = addEvent.admissionPrice;
            addEvent.categoryId = addEvent.category.id;
            addEvent.dateCreated = moment();
            addEvent.dateOfEvent = addEvent.startDate;
            addEvent.description = addEvent.description;
            addEvent.endTime = addEvent.endDate;
            addEvent.location = addEvent.location;
            addEvent.name = addEvent.name;
            addEvent.status = "private";

            console.log(`price: ${addEvent.admissionPrice} category ID:  ${addEvent.category.id}`);
            console.log(`category name: ${addEvent.category.name}`);
            console.log(`date created: ${addEvent.dateCreated} end time: ${addEvent.endTime}`);
            console.log(`description: ${addEvent.description}`);
            console.log(`date of event: ${addEvent.dateOfEvent} location: ${addEvent.location}`);
            console.log(`name: ${addEvent.name}`);

            this.$http.post('/api/events', addEvent)
                .then((response) => {
                    this.$state.reload();
                    this.displayToast(this.$mdToast);
                })
                .catch((reason) => {
                    console.log(reason);
                });

        }

        //constructor info used to build the 'add event' page pull-downs
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $mdToast: ng.material.IToastService) {
            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                });

        }
    };



    export class EventController {
        public event;


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) { }

        public addEvent(event) {
            this.$http.post('/api/event', event)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);

                });

            this.$http.delete('/api/events', event)
                .then((response) => {
                    this.$state.reload();


                })
        };
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class UserController {
        public userData;

        /*constructor(private $http: ng.IHttpService) {
            $http.get().then((results) => {
                this.userData = results.data;
            });
        }*/


    }

    export class GroupController {

        public users;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/user').then((results) => {
                this.users = results.data;
            });
        }

        public addGroup(group) {
            this.$http.post('/api/groups', group)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });

        }


    }
    export class MyEventsController {
        public events;
        public myevents;


        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {

            $http.get(`/api/events/myevents`)
                .then((response) => {
                    this.events = response.data;
                });
            $http.get('/api/events/mycreatedevents')
                .then((response) => {
                    this.myevents = response.data;
                });
        }

        public deleteEvent(eventId) {
            console.log(eventId);
            var p = { eventId: eventId };
            //this.$http.delete(`/api/events/${event.id}`, event)
            this.$http.delete(`/api/events/myevents`, {params: p})
                .then((response) => {
                    this.$state.reload();

                });
        }
    }


    export class EditEventController {

        public event;
        public categories;
        constructor(private $http: ng.IHttpService, private $stateParams, private $state: ng.ui.IStateService) {
            var p = { eventId: $stateParams.id };

            $http.get(`/api/events/${$stateParams.id}`, { params: p })
                .then((response) => {
                    this.event = response.data;
                }),
                $http.get('/api/category')
                    .then((response) => {
                        this.categories = response.data;
                    });
        }



        public updateEvent(event) {
            var p = { eventId: this.$stateParams.id };
            this.$http.put(`/api/events/${this.$stateParams.id}`, event, { params: p })
                .then((response) => {
                    this.$state.go('eventSearch');
                }).catch((reason) => {
                    console.log(reason);
                });
        }

        public deleteEvent(event) {
            this.$http.delete(`/api/events/${this.$stateParams.id}`, event)
                .then((response) => {
                    this.$state.go('eventSearch');

                });
        }
    }












    //public editing
    //constructor(private $http: ng.IHttpService) {
    //    $http.get('/api/events')
    //        .then((response) => {
    //            this.editing = response.data;
    //        })
    //}
    //$http.get(`/api/events/${this.eInfo.id}`)
//    .then((response) =>
//    {
//        this.eInfo = response.data;
//    })


    export class EventDetailsController {
        public eventSearchData;

        constructor(private $http: ng.IHttpService, private $stateParams) {
            var p = { eventId: $stateParams.id };

            $http.get(`/api/events/${$stateParams.id}`, { params: p })
                .then((response) => {
                    this.eventSearchData = response.data;
                })
        }

    }

    export class TestController {
        public message = 'Hello from the test page!';
    }

}

