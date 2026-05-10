using KitchenService.Dtos;

namespace KitchenService.Abstractions;

public interface IKitchenService
{
    Task Create(KitchenOrderCreationDto kitchenOrderCreationDto);

    Task<List<KitchenOrderDto>> GetAll();
}