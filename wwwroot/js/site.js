// Write your Javascript code.
new Vue({
    el: '#app',
    data: {
        todos: [],
        newTodo: '',
    },
    mounted: function() {
        this.$http.get('/api/todo').then(function(response) {
            this.todos = response.body;
        });
    },
    methods: {
        addTodo: function () {
            if (this.newTodo.length === 0) return;

            var data = {
                text: this.newTodo,
                isDone: false
            };

            this.todos.push(data);

            this.$http.post('/api/todo', data).then(function(response) {
                this.todos.pop();
                this.todos.push(response.body);
                this.newTodo = '';
            }, function() {
                this.todos.pop();
            })
        },
        toggleDone: function (todo) {
            var changedData = {
                id: todo.id,
                text: todo.text,
                isDone: !todo.isDone
            }
            this.$http.put('/api/todo/' + todo.id, changedData).then(function() {
                todo.isDone = !todo.isDone;
            });
        }
    }
})