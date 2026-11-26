--
-- PostgreSQL database dump
--

\restrict baGuZzVq6WEaVsfv3kzRNtnXfDnaxgpBjj2HuORgjARJo05zIdjVSBoac603L4v

-- Dumped from database version 18.1
-- Dumped by pg_dump version 18.1

-- Started on 2026-11-26 21:39:29

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 25252)
-- Name: categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.categories OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 25257)
-- Name: categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categories_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.categories_id_seq OWNER TO postgres;

--
-- TOC entry 5125 (class 0 OID 0)
-- Dependencies: 220
-- Name: categories_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categories_id_seq OWNED BY public.categories.id;


--
-- TOC entry 221 (class 1259 OID 25258)
-- Name: order_items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.order_items (
    id integer NOT NULL,
    order_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    price numeric(10,2) NOT NULL,
    CONSTRAINT check_order_price CHECK ((price >= (0)::numeric)),
    CONSTRAINT check_order_quantity CHECK ((quantity > 0))
);


ALTER TABLE public.order_items OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 25268)
-- Name: order_items_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_items_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.order_items_id_seq OWNER TO postgres;

--
-- TOC entry 5126 (class 0 OID 0)
-- Dependencies: 222
-- Name: order_items_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.order_items_id_seq OWNED BY public.order_items.id;


--
-- TOC entry 223 (class 1259 OID 25269)
-- Name: orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.orders (
    id integer NOT NULL,
    user_id integer NOT NULL,
    order_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    total_sum numeric(10,2) DEFAULT 0 NOT NULL
);


ALTER TABLE public.orders OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 25280)
-- Name: orders_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.orders_id_seq OWNER TO postgres;

--
-- TOC entry 5127 (class 0 OID 0)
-- Dependencies: 224
-- Name: orders_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_id_seq OWNED BY public.orders.id;


--
-- TOC entry 225 (class 1259 OID 25281)
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    category_id integer NOT NULL,
    price numeric(10,2) NOT NULL,
    quantity integer DEFAULT 0 NOT NULL,
    description text,
    is_active boolean DEFAULT true NOT NULL,
    CONSTRAINT check_product_price CHECK ((price >= (0)::numeric)),
    CONSTRAINT check_product_quantity CHECK ((quantity >= 0))
);


ALTER TABLE public.products OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 25294)
-- Name: products_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.products_id_seq OWNER TO postgres;

--
-- TOC entry 5128 (class 0 OID 0)
-- Dependencies: 226
-- Name: products_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;


--
-- TOC entry 227 (class 1259 OID 25295)
-- Name: receipt_items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.receipt_items (
    id integer NOT NULL,
    receipt_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    price numeric(10,2) NOT NULL,
    CONSTRAINT check_receipt_price CHECK ((price >= (0)::numeric)),
    CONSTRAINT check_receipt_quantity CHECK ((quantity > 0))
);


ALTER TABLE public.receipt_items OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 25305)
-- Name: receipt_items_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.receipt_items_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.receipt_items_id_seq OWNER TO postgres;

--
-- TOC entry 5129 (class 0 OID 0)
-- Dependencies: 228
-- Name: receipt_items_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.receipt_items_id_seq OWNED BY public.receipt_items.id;


--
-- TOC entry 229 (class 1259 OID 25306)
-- Name: receipts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.receipts (
    id integer NOT NULL,
    user_id integer NOT NULL,
    receipt_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    items_count integer DEFAULT 0 NOT NULL,
    total_amount numeric(12,2) DEFAULT 0 NOT NULL
);


ALTER TABLE public.receipts OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 25313)
-- Name: receipts_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.receipts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.receipts_id_seq OWNER TO postgres;

--
-- TOC entry 5130 (class 0 OID 0)
-- Dependencies: 230
-- Name: receipts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.receipts_id_seq OWNED BY public.receipts.id;


--
-- TOC entry 236 (class 1259 OID 25667)
-- Name: restock_request_items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.restock_request_items (
    id integer NOT NULL,
    request_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    CONSTRAINT restock_request_items_quantity_check CHECK ((quantity > 0))
);


ALTER TABLE public.restock_request_items OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 25666)
-- Name: restock_request_items_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.restock_request_items_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.restock_request_items_id_seq OWNER TO postgres;

--
-- TOC entry 5131 (class 0 OID 0)
-- Dependencies: 235
-- Name: restock_request_items_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.restock_request_items_id_seq OWNED BY public.restock_request_items.id;


--
-- TOC entry 234 (class 1259 OID 25649)
-- Name: restock_requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.restock_requests (
    id integer NOT NULL,
    user_id integer NOT NULL,
    request_date timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    status character varying(50) DEFAULT 'Ожидает рассмотрения'::character varying NOT NULL
);


ALTER TABLE public.restock_requests OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 25648)
-- Name: restock_requests_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.restock_requests_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.restock_requests_id_seq OWNER TO postgres;

--
-- TOC entry 5132 (class 0 OID 0)
-- Dependencies: 233
-- Name: restock_requests_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.restock_requests_id_seq OWNED BY public.restock_requests.id;


--
-- TOC entry 231 (class 1259 OID 25314)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    full_name character varying(100) NOT NULL,
    login character varying(50) NOT NULL,
    password character varying(255) NOT NULL,
    role character varying(20) NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 25322)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 5133 (class 0 OID 0)
-- Dependencies: 232
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4896 (class 2604 OID 25323)
-- Name: categories id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories ALTER COLUMN id SET DEFAULT nextval('public.categories_id_seq'::regclass);


--
-- TOC entry 4897 (class 2604 OID 25324)
-- Name: order_items id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_items ALTER COLUMN id SET DEFAULT nextval('public.order_items_id_seq'::regclass);


--
-- TOC entry 4898 (class 2604 OID 25325)
-- Name: orders id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN id SET DEFAULT nextval('public.orders_id_seq'::regclass);


--
-- TOC entry 4901 (class 2604 OID 25326)
-- Name: products id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);


--
-- TOC entry 4904 (class 2604 OID 25327)
-- Name: receipt_items id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipt_items ALTER COLUMN id SET DEFAULT nextval('public.receipt_items_id_seq'::regclass);


--
-- TOC entry 4905 (class 2604 OID 25328)
-- Name: receipts id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipts ALTER COLUMN id SET DEFAULT nextval('public.receipts_id_seq'::regclass);


--
-- TOC entry 4913 (class 2604 OID 25670)
-- Name: restock_request_items id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_request_items ALTER COLUMN id SET DEFAULT nextval('public.restock_request_items_id_seq'::regclass);


--
-- TOC entry 4910 (class 2604 OID 25652)
-- Name: restock_requests id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_requests ALTER COLUMN id SET DEFAULT nextval('public.restock_requests_id_seq'::regclass);


--
-- TOC entry 4909 (class 2604 OID 25329)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 5102 (class 0 OID 25252)
-- Dependencies: 219
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.categories (id, name) FROM stdin;
1	Семена
2	Садовый инвентарь
3	Удобрения
4	Грунт и почва
5	Средства для ухода
6	Уют и декор
11	Открытки
\.


--
-- TOC entry 5104 (class 0 OID 25258)
-- Dependencies: 221
-- Data for Name: order_items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.order_items (id, order_id, product_id, quantity, price) FROM stdin;
1	1	9	1	700.00
2	1	11	2	2500.00
3	1	38	6	300.00
4	2	5	13	450.00
5	3	9	2	700.00
6	3	7	10	230.00
7	4	7	2	230.00
8	4	1	5	150.00
9	5	1	9	150.00
\.


--
-- TOC entry 5106 (class 0 OID 25269)
-- Dependencies: 223
-- Data for Name: orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.orders (id, user_id, order_date, total_sum) FROM stdin;
1	3	2026-11-26 20:50:35.697575	7500.00
2	4	2026-11-26 20:53:02.214755	5850.00
3	4	2026-11-26 20:53:43.77233	3700.00
4	5	2026-11-26 20:56:10.520628	1210.00
5	5	2026-11-26 20:57:01.057479	1350.00
\.


--
-- TOC entry 5108 (class 0 OID 25281)
-- Dependencies: 225
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (id, name, category_id, price, quantity, description, is_active) FROM stdin;
3	Лопата садовая	2	230.00	133	Садовая лопата с металлическим полотном	t
54	Семена кукурузы	1	100.00	0	Семена кукурузы для выращивание на грядках	f
10	Садовый фонарь	6	950.00	22	Декоративный фонарь для сада	t
11	Плед в клеточку	6	2500.00	8	Уютный бордовый плед в клеточку, теплый	t
38	Семена петрушки	4	300.00	69	Семена для выращивания петрушки в огороде	t
8	Средство от вредителей	5	550.00	70	Средство для защиты растений от вредителей	t
6	Удобрение универсальное	3	600.00	98	Комплексное удобрение для растений	t
5	Мочевина	3	450.00	0	Азотное удобрение для садовых и огородных культур	t
9	Лейка садовая	5	700.00	16	Пластиковая лейка для полива растений	t
4	Грабли садовые	2	850.00	27	Грабли для обработки почвы и уборки территории	t
2	Семена огурцов	1	120.00	95	Семена огурцов для дачного участка	t
7	Грунт для рассады	4	230.00	15	Готовый грунт для выращивания рассады	t
1	Семена томатов	1	150.00	61	Семена томатов для выращивания в открытом грунте	t
\.


--
-- TOC entry 5110 (class 0 OID 25295)
-- Dependencies: 227
-- Data for Name: receipt_items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.receipt_items (id, receipt_id, product_id, quantity, price) FROM stdin;
1	1	1	20	150.00
2	1	38	15	240.00
3	2	10	12	800.00
4	3	38	40	230.00
5	3	8	50	400.00
6	3	6	35	250.00
7	4	4	15	560.00
8	4	2	55	120.00
9	5	1	5	120.00
\.


--
-- TOC entry 5112 (class 0 OID 25306)
-- Dependencies: 229
-- Data for Name: receipts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.receipts (id, user_id, receipt_date, items_count, total_amount) FROM stdin;
1	3	2026-11-26 20:49:43.429961	35	6600.00
2	3	2026-11-26 20:50:06.826263	12	9600.00
3	4	2026-11-26 20:52:19.15762	125	37950.00
4	5	2026-11-26 20:55:23.346635	70	15000.00
5	5	2026-11-26 20:56:25.960723	5	600.00
\.


--
-- TOC entry 5119 (class 0 OID 25667)
-- Dependencies: 236
-- Data for Name: restock_request_items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.restock_request_items (id, request_id, product_id, quantity) FROM stdin;
1	1	5	35
2	1	11	20
3	2	7	20
\.


--
-- TOC entry 5117 (class 0 OID 25649)
-- Dependencies: 234
-- Data for Name: restock_requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.restock_requests (id, user_id, request_date, status) FROM stdin;
1	4	2026-11-26 20:54:16.656927+03	Ожидает рассмотрения
2	5	2026-11-26 20:57:36.558665+03	Отклонена
\.


--
-- TOC entry 5114 (class 0 OID 25314)
-- Dependencies: 231
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, full_name, login, password, role) FROM stdin;
3	Берёзкин Егор Витальевич	egor0909	egor135	administrator
4	Будина Ирина Сергеевна	irina5555	irina246	sotrudnik
5	Козырева Мария Михайловна	maria2468	maria123	sotrudnik
\.


--
-- TOC entry 5134 (class 0 OID 0)
-- Dependencies: 220
-- Name: categories_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categories_id_seq', 11, true);


--
-- TOC entry 5135 (class 0 OID 0)
-- Dependencies: 222
-- Name: order_items_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_items_id_seq', 9, true);


--
-- TOC entry 5136 (class 0 OID 0)
-- Dependencies: 224
-- Name: orders_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_id_seq', 5, true);


--
-- TOC entry 5137 (class 0 OID 0)
-- Dependencies: 226
-- Name: products_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.products_id_seq', 82, true);


--
-- TOC entry 5138 (class 0 OID 0)
-- Dependencies: 228
-- Name: receipt_items_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.receipt_items_id_seq', 9, true);


--
-- TOC entry 5139 (class 0 OID 0)
-- Dependencies: 230
-- Name: receipts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.receipts_id_seq', 5, true);


--
-- TOC entry 5140 (class 0 OID 0)
-- Dependencies: 235
-- Name: restock_request_items_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.restock_request_items_id_seq', 3, true);


--
-- TOC entry 5141 (class 0 OID 0)
-- Dependencies: 233
-- Name: restock_requests_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.restock_requests_id_seq', 2, true);


--
-- TOC entry 5142 (class 0 OID 0)
-- Dependencies: 232
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 5, true);


--
-- TOC entry 4922 (class 2606 OID 25331)
-- Name: categories categories_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_name_key UNIQUE (name);


--
-- TOC entry 4924 (class 2606 OID 25333)
-- Name: categories categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);


--
-- TOC entry 4926 (class 2606 OID 25335)
-- Name: order_items order_items_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_items
    ADD CONSTRAINT order_items_pkey PRIMARY KEY (id);


--
-- TOC entry 4928 (class 2606 OID 25337)
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (id);


--
-- TOC entry 4930 (class 2606 OID 25339)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);


--
-- TOC entry 4932 (class 2606 OID 25341)
-- Name: receipt_items receipt_items_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipt_items
    ADD CONSTRAINT receipt_items_pkey PRIMARY KEY (id);


--
-- TOC entry 4934 (class 2606 OID 25343)
-- Name: receipts receipts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipts
    ADD CONSTRAINT receipts_pkey PRIMARY KEY (id);


--
-- TOC entry 4944 (class 2606 OID 25679)
-- Name: restock_request_items restock_request_items_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_request_items
    ADD CONSTRAINT restock_request_items_pkey PRIMARY KEY (id);


--
-- TOC entry 4941 (class 2606 OID 25660)
-- Name: restock_requests restock_requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_requests
    ADD CONSTRAINT restock_requests_pkey PRIMARY KEY (id);


--
-- TOC entry 4936 (class 2606 OID 25345)
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- TOC entry 4938 (class 2606 OID 25347)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4942 (class 1259 OID 25691)
-- Name: idx_restock_items_request; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_restock_items_request ON public.restock_request_items USING btree (request_id);


--
-- TOC entry 4939 (class 1259 OID 25690)
-- Name: idx_restock_requests_user; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_restock_requests_user ON public.restock_requests USING btree (user_id);


--
-- TOC entry 4945 (class 2606 OID 25348)
-- Name: order_items fk_order_item_order; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_items
    ADD CONSTRAINT fk_order_item_order FOREIGN KEY (order_id) REFERENCES public.orders(id) ON DELETE CASCADE;


--
-- TOC entry 4946 (class 2606 OID 25353)
-- Name: order_items fk_order_item_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_items
    ADD CONSTRAINT fk_order_item_product FOREIGN KEY (product_id) REFERENCES public.products(id);


--
-- TOC entry 4947 (class 2606 OID 25358)
-- Name: orders fk_order_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT fk_order_user FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- TOC entry 4948 (class 2606 OID 25363)
-- Name: products fk_product_category; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT fk_product_category FOREIGN KEY (category_id) REFERENCES public.categories(id);


--
-- TOC entry 4949 (class 2606 OID 25368)
-- Name: receipt_items fk_receipt_item_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipt_items
    ADD CONSTRAINT fk_receipt_item_product FOREIGN KEY (product_id) REFERENCES public.products(id);


--
-- TOC entry 4950 (class 2606 OID 25373)
-- Name: receipt_items fk_receipt_item_receipt; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipt_items
    ADD CONSTRAINT fk_receipt_item_receipt FOREIGN KEY (receipt_id) REFERENCES public.receipts(id) ON DELETE CASCADE;


--
-- TOC entry 4951 (class 2606 OID 25378)
-- Name: receipts fk_receipt_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.receipts
    ADD CONSTRAINT fk_receipt_user FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- TOC entry 4953 (class 2606 OID 25685)
-- Name: restock_request_items fk_restock_items_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_request_items
    ADD CONSTRAINT fk_restock_items_product FOREIGN KEY (product_id) REFERENCES public.products(id);


--
-- TOC entry 4954 (class 2606 OID 25680)
-- Name: restock_request_items fk_restock_items_request; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_request_items
    ADD CONSTRAINT fk_restock_items_request FOREIGN KEY (request_id) REFERENCES public.restock_requests(id) ON DELETE CASCADE;


--
-- TOC entry 4952 (class 2606 OID 25661)
-- Name: restock_requests fk_restock_requests_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.restock_requests
    ADD CONSTRAINT fk_restock_requests_user FOREIGN KEY (user_id) REFERENCES public.users(id);


-- Completed on 2026-11-26 21:39:30

--
-- PostgreSQL database dump complete
--

\unrestrict baGuZzVq6WEaVsfv3kzRNtnXfDnaxgpBjj2HuORgjARJo05zIdjVSBoac603L4v

