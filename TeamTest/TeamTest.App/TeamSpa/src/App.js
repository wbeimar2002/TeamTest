import React from 'react';
import logo from './assets/images/logo.svg';
import './assets/css/App.css';
import {getCategories} from './api/categories'

import MiComponente from './components/MiComponente';

function HolaMundo(nombre, edad)
{
  var presentacion = (
    <div>
      <h2>hola, soy {nombre}</h2>
      <h3>Tengo {edad} años</h3>
    </div>
  );
  let categories = getCategories();
  console.log(categories);
  return presentacion;
}



function App() {
var nombre = "Alexander";


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Hola Bienvenido al curso de React de Alexander Gonzalez. para Team
        </p>
        {
          HolaMundo(nombre,33)
        }
      
      <section className="componentes">
        <MiComponente/>

      </section>
      
      </header>
    </div>
  );
}

export default App;
