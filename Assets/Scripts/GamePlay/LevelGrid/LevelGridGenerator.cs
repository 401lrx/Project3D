using Assets.Scripts.BaseUtils;
using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGridGenerator : MonoSingleton<LevelGridGenerator>
{
    public Tilemap tilemap;
    public Dictionary<Vector3Int, LevelGridTileObject> tile_dictionary = new Dictionary<Vector3Int, LevelGridTileObject>();
    void TraverseWithGetTilesBlock()
    {
        // ��ȡTilemap�ĵ�Ԫ��߽� :cite[3]
        BoundsInt area = tilemap.cellBounds;

        // ������ȡ�ñ߽��ڵ�������Ƭ :cite[2]
        TileBase[] allTiles = tilemap.GetTilesBlock(area);

        // ������Ƭ����
        for (int i = 0; i < allTiles.Length; i++)
        {
            TileBase tile = allTiles[i];
            if (tile != null)
            {
                // ������ת��Ϊλ������
                int x = i % area.size.x + area.xMin;
                int y = i / area.size.x + area.yMin;
                Vector3Int position = new Vector3Int(x, y, 0);

                Vector3 objpos = tilemap.GetCellCenterWorld(position);

                Debug.Log($"λ�� {position} ������Ƭ: {tile.name}");
                string tile_obj_name = GameTableConfig.Instance.Config_TileBlocks.FindFirstLine(x => x.TileSpriteName == tile.name).BlockObject;
                // �����ﴦ�������Ƭ�߼�
                GameObject new_obj = Resources.Load<GameObject>("GameObjectPrefabs/" + tile_obj_name);

                GameObject sp_obj = Instantiate(new_obj, LevelManager.Instance.LevelObjectsRoot);
                sp_obj.transform.position = objpos;

                if (tile_dictionary.ContainsKey(position))
                {
                    tile_dictionary[position] = sp_obj.GetComponent<LevelGridTileObject>();
                }
                else
                {
                    tile_dictionary.Add(position, sp_obj.GetComponent<LevelGridTileObject>());
                }

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        TraverseWithGetTilesBlock();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TryAttach(Vector3Int pos, GameObject obj)
    {

        if (tile_dictionary.ContainsKey(pos))
        {
            tile_dictionary[pos].TryAttachObject(obj);
        }
    }
}
