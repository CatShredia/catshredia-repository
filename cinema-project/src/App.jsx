import { useEffect, useState } from "react";

// компонент card
const Card = ({ title }) => {
  const [hasLiked, setHasLiked] = useState(false);

  useEffect(() => {
    console.log(`this movie ${title} is ${hasLiked}`);
  });

  return (
    <div className="card">
      <h2>{title}</h2>

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
