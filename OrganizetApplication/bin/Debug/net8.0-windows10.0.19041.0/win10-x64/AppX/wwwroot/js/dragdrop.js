window.dragAndDrop = {
    enableDragAndDrop: function () {
        const cards = document.querySelectorAll('.kanban-card');
        const columns = document.querySelectorAll('.kanban-column');

        cards.forEach(card => {
            card.addEventListener('dragstart', function (e) {
                e.dataTransfer.setData('text/plain', e.target.id);
                e.target.classList.add('dragging');
            });

            card.addEventListener('dragend', function (e) {
                e.target.classList.remove('dragging');
            });
        });

        columns.forEach(column => {
            column.addEventListener('dragover', function (e) {
                e.preventDefault();
            });

            column.addEventListener('drop', function (e) {
                e.preventDefault();
                const cardId = e.dataTransfer.getData('text/plain');
                const card = document.getElementById(cardId);
                if (card) {
                    column.appendChild(card);
                }
            });
        });
    }
};
