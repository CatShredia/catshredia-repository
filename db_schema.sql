create table if not exists country
(
    id   bigserial primary key,
    name varchar(50) not null
);

create table if not exists city
(
    id         bigserial primary key,
    name       varchar(50) not null,
    id_country bigint      not null,
    foreign key (id_country) references country (id)
);

create table if not exists street
(
    id      bigserial primary key,
    name    varchar(50) not null,
    id_city bigint      not null,
    foreign key (id_city) references city (id)
);

-- address --> street --> city --> country
create table if not exists address
(
    id           bigserial primary key,
    house_number varchar(20) not null,
    corpus       varchar(50),
    apartment    varchar(50),
    id_street    bigint      not null,
    foreign key (id_street) references street (id),
    unique (id_street, house_number, corpus, apartment)
);

create table if not exists warehouses
(
    id         bigserial primary key,
    name       varchar(50) not null,
    id_address bigint      not null,
    foreign key (id_address) references address (id)
);

create table if not exists users
(
    id         bigserial primary key,
    login      varchar(255) not null,
    password   text not null,
    created_at timestamptz not null default (now()),
    edited_at  timestamptz not null default (now())
);

create table if not exists sellers
(
    id      bigserial primary key,
    id_user bigint not null,
    foreign key (id_user) references users (id),
    unique (id_user)
);

create table if not exists categories
(
    id   bigserial primary key,
    name varchar(50) not null
);

create table if not exists tags
(
    id   bigserial primary key,
    name varchar(50) not null
);

create table if not exists products
(
    id          bigserial primary key,
    sku         varchar(100)  not null unique,
    title       varchar(50)  not null,
    description text not null,
    id_seller   bigint       not null,
    foreign key (id_seller) references sellers (id),
    id_category bigint       not null,
    foreign key (id_category) references categories (id),
    created_at  timestamptz  not null default (now()),
    edited_at   timestamptz  not null default (now())
);

create table if not exists tags_product_list
(
    id_product bigint not null,
    foreign key (id_product) references products (id),
    id_tag     bigint not null,
    foreign key (id_tag) references tags (id)
);

create table if not exists inventory
(
    id           bigserial primary key,
    id_product   bigint not null,
    foreign key (id_product) references products (id),
    id_warehouse bigint not null,
    foreign key (id_warehouse) references warehouses (id),
    quantity     INT    NOT NULL CHECK (quantity >= 0),
    reserved     INT    NOT NULL DEFAULT 0 CHECK (reserved >= 0 AND reserved <= quantity),
    UNIQUE (id_product, id_warehouse)
);

-- in - arrived to warehouse
-- out - out from warehouse
-- adjust - inventorization or another correction
-- unreserved - cancel order
CREATE TYPE txn_type AS ENUM ('in', 'out', 'adjust', 'reserved', 'unreserved');

CREATE TABLE inventory_transactions
(
    id            BIGSERIAL PRIMARY KEY,
    inventory_id  BIGINT   NOT NULL REFERENCES inventory (id),
    txn_type      txn_type NOT NULL,
    quantity      INT      NOT NULL,
    batch_id      UUID,
    cost_per_unit NUMERIC(12, 2),
    created_at    TIMESTAMPTZ DEFAULT NOW()
);

CREATE INDEX idx_inventory_warehouse ON inventory (id_warehouse);
CREATE INDEX idx_inventory_product ON inventory (id_product);
CREATE INDEX idx_invtxn_inventory ON inventory_transactions (inventory_id);
CREATE INDEX idx_products_seller ON products (id_seller);
CREATE INDEX idx_tags_product_list_tag ON tags_product_list (id_tag);
CREATE INDEX idx_tags_product_list_product_tag ON tags_product_list (id_product, id_tag);
CREATE INDEX idx_invtxn_batch ON inventory_transactions (batch_id) WHERE batch_id IS NOT NULL;