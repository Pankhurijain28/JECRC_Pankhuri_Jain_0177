const apiUrl = "http://localhost:5228/api/todo";
let currentFilter = "all";

/* Load Tasks */
async function loadTasks() {

    try {

        const response = await fetch(apiUrl);
        const tasks = await response.json();

        const search = document.getElementById("searchInput").value.toLowerCase();
        const list = document.getElementById("taskList");

        list.innerHTML = "";

        tasks.forEach(task => {

            if (currentFilter === "active" && task.isCompleted) return;
            if (currentFilter === "completed" && !task.isCompleted) return;

            if (!task.taskName.toLowerCase().includes(search)) return;

            const li = document.createElement("li");

            li.innerHTML = `
            <input type="checkbox" ${task.isCompleted ? "checked" : ""}
            onchange="completeTask(${task.id}, this.checked)">

            <span class="taskText ${task.isCompleted ? "completed" : ""}">
            ${task.taskName}
            </span>

            <span class="priority ${task.priority.toLowerCase()}">
            ${task.priority}
            </span>

            <div class="actions">
            <button onclick="editTask(${task.id}, '${task.taskName}', '${task.priority}', ${task.isCompleted})">Edit</button>
            <button onclick="deleteTask(${task.id})">Delete</button>
            </div>
            `;

            list.appendChild(li);
        });

    } catch (error) {
        console.error("Error loading tasks:", error);
    }
}


/* Filter Tasks */
function filterTasks(type) {
    currentFilter = type;
    loadTasks();
}


/* Dark Mode */
function toggleDarkMode() {
    document.body.classList.toggle("dark");
}


/* Add Task */
async function addTask() {

    const taskInput = document.getElementById("taskInput");
    const priority = document.getElementById("priority").value;

    if (taskInput.value.trim() === "") return;

    try {

        await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                taskName: taskInput.value,
                priority: priority,
                isCompleted: false
            })
        });

        taskInput.value = "";
        loadTasks();

    } catch (error) {
        console.error("Error adding task:", error);
    }
}


/* Edit Task */
async function editTask(id, oldTask, oldPriority, completed) {

    const newTask = prompt("Edit task:", oldTask);

    if (!newTask) return;

    try {

        await fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                id: id,
                taskName: newTask,
                priority: oldPriority,
                isCompleted: completed
            })
        });

        loadTasks();

    } catch (error) {
        console.error("Error editing task:", error);
    }
}


/* Delete Task */
async function deleteTask(id) {

    try {

        await fetch(`${apiUrl}/${id}`, {
            method: "DELETE"
        });

        loadTasks();

    } catch (error) {
        console.error("Error deleting task:", error);
    }
}


/* Mark Complete */
async function completeTask(id, status) {

    try {

        const response = await fetch(`${apiUrl}`);
        const tasks = await response.json();

        const task = tasks.find(t => t.id === id);

        await fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                id: id,
                taskName: task.taskName,
                priority: task.priority,
                isCompleted: status
            })
        });

        loadTasks();

    } catch (error) {
        console.error("Error updating task:", error);
    }
}


/* Load tasks on page start */
loadTasks();