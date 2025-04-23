import { useEffect, useState } from "react";

// компонент card
const Card = ({ title }) => {
  const [hasLiked, setHasLiked] = useState(false);
  const [count, setCount] = useState(0);

  // deps [hasLiked] используется для того, чтобы функция запускалась, только при изменении hasLiked
  useEffect(() => {
    console.log(`this movie ${title} is ${hasLiked} ${count}`);
  }, [hasLiked]);

  return (
    <div
      className="card"
      onClick={() => setCount((prevState) => prevState + 1)}
    >
      <h2>{title}</h2>

      <p className="count">{count || null}</p>

      <button className="confirm-button" onClick={() => setHasLiked(!hasLiked)}>
        {hasLiked ? "❤️" : "😥"}
      </button>
    </div>
  );
};

const App = () => {
  return (
    <section className="section">
      <div className="container">
        <div className="cards">
          <Card title="Star Wars" />
          <Card title="Bad Boy" />
          <Card title="Jim" />
          <Card title="Joke" />
          <Card title="I have spoken" />
        </div>
      </div>
    </section>
  );
};

export default App;
