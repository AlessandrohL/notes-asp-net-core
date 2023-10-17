const $statusNote = document.querySelector("#statusNote");

if ($statusNote != null) {
    setTimeout(() => {
      $statusNote.remove();
    }, 4000)
}

const template = (data = {}) => {
  const {
    title, 
    description,
    expirationDate,
    priority,
    state,
    tags
  } = data;

  return `
  <figure class="note-detail-container">
    <h3 class="note-detail-title">${title}</h3>
    <p class="note-detail-description">${description}</p>
  </figure>
  `
}


const getData = async (id = '') => {

  if (id == '') return

  const res = await fetch(`${location.origin}/Note/Detail/${id}`);
  const data = await res.json();

  return data;
}


document.addEventListener('click', async e => {

  if (e.target.matches('.header-settings')) {
    Swal.fire('No disponible!')
  }

  if (e.target.dataset.itemId) {
    const noteId = e.target.dataset.itemId

    const data = await getData(noteId)

    Swal.fire({
      html: template(data),
      confirmButtonText: 'Cool'
    })
  }

})