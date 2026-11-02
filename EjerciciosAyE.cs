// Ejercicio A

// A1: C.
// A2: A.
// A3: D.
// A4: B.
// A5: C.
// A6: A.
// A7: B. La C casi no la descarto por aprender el .ToList() que me confundió, pero recordé y revisé.
// A8: D. Descarté las demás porque en C# se debe desuscribir manualmente.
// A9: B. Es la que más me costó, pero discerní que el evento es Click y la descarté.
// A10: C.

// Ejercicio E

// E1: Strategy, porque se pueden crear diferentes estrategias para cada tipo de envío que puede seleccionar el usuario,
// más aún sabiendo que se seguirán agregando tipos de envío, como Dron en un mes.
// También se puede utilizar Factory, ya que se puede crear la estrategia correcta según el usuario.

// E2: Observer, ya que se deberá notificar a la pantalla de la cocina, la tablet del mozo y la caja de que el 
// pedido del restaurante está listo, y encima después también notificar al cliente por whatsapp, que es un suscriptor más.

// E3: Singleton, ya que se debe inicializar el objeto, en este caso el objeto de configuración
// que contiene a la moneda, la sucursal y la carpeta, UNA sola vez,
// y cada vez que se llame a ese objeto, devolver ése mismo que se creó la primera vez.
// Cada formulario tiene su propia configuración, por eso cuando se cambia la sucursal en una pantalla, las demás persisten con la anterior.

// E4: Factory, ya que el medio de pago llega como texto desde el JSON y se debe crear el objeto exacto 
// y Strategy, porque cada medio de pago hace un cálculo distinto para cada uno y se debe hacer la estrategia para cada uno.

// E5: Ninguna... no agrega ninguna funcionalidad que ya no haga ni algo que necesite.
// el repo es una única vez en el Program.cs y nunca cambia.
